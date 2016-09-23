namespace BalanceDataSync
{
    public interface ISyncDataHandler
    {
        void ImportDayData();
        void ImportMonthData();
    }
}