using System;

namespace MLAA.Data.Linq2Sql
{
    public static class DomainEvents
    {
        private static IEventBroker _eventBroker;

        public static void SetEventBrokerStrategy(IEventBroker eventBroker)
        {
            _eventBroker = eventBroker;
        }

        public static void Raise<TDomainEvent>(TDomainEvent domainEvent)
        {
            var eventBroker = _eventBroker;
            if (eventBroker == null)
                throw new InvalidOperationException(
                    "You need to provide an event broker first!");

            eventBroker.Raise(domainEvent);
        }
    }
}