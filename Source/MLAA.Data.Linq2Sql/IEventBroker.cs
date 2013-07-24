namespace MLAA.Data.Linq2Sql
{
    public interface IEventBroker
    {
        void Raise<T>(T domainEvent);
    }
}