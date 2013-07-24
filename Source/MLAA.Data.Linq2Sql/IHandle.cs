namespace MLAA.Data.Linq2Sql
{
    public interface IHandle<TDomainEvent>
    {
        void Handle(TDomainEvent domainEvent);
    }
}