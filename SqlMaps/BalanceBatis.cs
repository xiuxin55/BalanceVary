using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlMaps
{
    public class BalanceBatis: BaseBatis
    {
        public static ISqlMapper Batis
        {
            get
            {
                StartBatis(CommonData.BalanceSqlConfig);
                return SqlMap;
            }
        }
    }
}
