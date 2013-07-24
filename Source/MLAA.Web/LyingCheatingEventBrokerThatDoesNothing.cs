using MLAA.Data.Linq2Sql;

namespace MLAA.Web
{
    public class LyingCheatingEventBrokerThatDoesNothing : IEventBroker
    {
        public void Raise<T>(T domainEvent)
        {
            // Ha ha ha ha ha!!!!
        }
    }
}