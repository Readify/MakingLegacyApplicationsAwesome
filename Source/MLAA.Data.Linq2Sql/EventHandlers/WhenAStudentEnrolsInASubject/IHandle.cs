namespace MLAA.Data.Linq2Sql.EventHandlers.WhenAStudentEnrolsInASubject
{
    public interface IHandle<TDomainEvent>
    {
        void Handle(TDomainEvent domainEvent);
    }
}