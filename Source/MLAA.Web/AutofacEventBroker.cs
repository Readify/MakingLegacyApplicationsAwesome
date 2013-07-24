using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Web;
using MLAA.Data.Linq2Sql;

namespace MLAA.Web
{
    public class AutofacEventBroker : IEventBroker
    {
        public void Raise<T>(T domainEvent)
        {
            var cpa = (IContainerProviderAccessor)HttpContext.Current.ApplicationInstance;
            var cp = cpa.ContainerProvider;

            var handlers = cp.RequestLifetime.Resolve<IEnumerable<IHandle<T>>>();
            foreach (var handler in handlers)
            {
                handler.Handle(domainEvent);
            }
        }
    }
}