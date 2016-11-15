using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace WSBalanceClient
{
    /// <summary>
    /// Wcf服务调用辅助类
    /// </summary
    public static class ServiceInvokeHelper<TChannel> where TChannel : ICommunicationObject, new()
    {

        private static Dictionary<string, TChannel> _ChannelDic = new Dictionary<string, TChannel>();
        private static object _Lockhelper = new object();

        private static TResult TryFunc<TResult>(Func<TChannel, TResult> func, TChannel channel)
        {
            string tChannelName = typeof(TChannel).FullName;
            try
            {
                return func(channel);
            }
            catch (CommunicationException)
            {
                channel.Abort();
                lock (_Lockhelper)
                    _ChannelDic.Remove(tChannelName);
                throw;
            }
            catch (TimeoutException)
            {
                channel.Abort();
                lock (_Lockhelper)
                    _ChannelDic.Remove(tChannelName);
                throw;
            }
            catch (Exception)
            {
                channel.Abort();
                lock (_Lockhelper)
                    _ChannelDic.Remove(tChannelName);
                throw;
            }
        }

        private static TChannel GetChannel()
        {
            TChannel instance;
            string tChannelName = typeof(TChannel).FullName;
            if (!_ChannelDic.ContainsKey(tChannelName))
            {
                lock (_Lockhelper)
                {
                    instance = Activator.CreateInstance<TChannel>();
                    _ChannelDic.Add(tChannelName, instance);
                }
            }
            else
            {
                instance = _ChannelDic[tChannelName];
            }
            if (instance.State != CommunicationState.Opened && instance.State != CommunicationState.Opening)
                instance.Open();
            return instance;
        }

        /// <summary>
        /// 直接调用，无返回值
        /// </summary>
        public static void Invoke(Action<TChannel> action)
        {
            TChannel instance = GetChannel();
            TryFunc(
                client =>
                {
                    action(client);
                    return (object)null;
                }
                , instance);
        }
        /// <summary>
        /// 有返回值的调用
        /// </summary>
        public static TResult Invoke<TResult>(Func<TChannel, TResult> func)
        {
            TChannel instance = GetChannel();
            ICommunicationObject channel = instance as ICommunicationObject;
            TResult returnValue = default(TResult);
            returnValue = TryFunc(func, instance);
            return returnValue;
        }
    }
}
