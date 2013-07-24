using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Web;
using MLAA.Data.Linq2Sql;
using MLAA.Data.Linq2Sql.EventHandlers.WhenAStudentEnrolsInASubject;

namespace MLAA.Web
{
    public class AutofacEventBroker : IEventBroker
    {
        public void Raise<T>(T domainEvent)
        {
            var cpa = (IContainerProviderAccessor)HttpContext.Current.ApplicationInstance;
            var cp = cpa.ContainerProvider;

            var handler = cp.RequestLifetime.Resolve<IHandle<T>>();

            if (handler == null)
                throw new InvalidOperationException(
                    String.Format("Type not registered '{0}'", typeof(T).Name));

            handler.Handle(domainEvent);
        }
    }
}