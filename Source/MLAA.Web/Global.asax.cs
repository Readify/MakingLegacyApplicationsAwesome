using System;
using System.Configuration;
using System.Web;
using System.Web.Optimization;
using Autofac;
using Autofac.Integration.Web;
using MLAA.Data.Linq2Sql;
using MLAA.Data.Linq2Sql.Domain.Services;
using MLAA.Database;
using MLAA.Web.App_Start;

/// <summary>
/// 
/// </summary>

namespace MLAA.Web
{
    /// <summary>
    /// </summary>
    public class Global : HttpApplication, IContainerProviderAccessor
    {
        /// <summary>
        ///     Code that runs on application startup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Start(object sender, EventArgs e)
        {
            DatabaseUpgrader.Upgrade(
                ConfigurationManager.ConnectionStrings["DerpUniversityConnectionString"].ConnectionString);

            DomainEvents.SetEventBrokerStrategy(new AutofacEventBroker());

            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            BuildDependencies();
        }

        /// <summary>
        ///     Code that runs on application startup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void Application_Start(object sender, EventArgs e)
        private void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
        }

        // /// <summary>
        ///// Code that runs on application startup
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        ////private void Application_Start(object sender, EventArgs e)
        // private void Application_End(object sender, EventArgs e)
        private void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
        }

        private void Application_EndRequest(object sender, EventArgs e)
        {
        }

        // Provider that holds the application container.
        private static IContainerProvider _containerProvider;

        // Instance property that will be used by Autofac HttpModules
        // to resolve and inject dependencies.
        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }

        private static void BuildDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(typeof (Student).Assembly)
                   .Where(t => t.IsClosedTypeOf(typeof (IHandle<>)))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            builder.RegisterType<SmtpEmailSender>()
                   .AsImplementedInterfaces()
                   .SingleInstance();

            builder.RegisterAssemblyTypes(typeof (WebForm1ViewModel).Assembly)
                   .Where(t => t.Name.EndsWith("ViewModel"))
                   .AsSelf()
                   .InstancePerLifetimeScope();

            builder.Register(c => new DerpUniversityDataContext(
                                      ConfigurationManager.ConnectionStrings["DerpUniversityConnectionString"].ConnectionString))
                   .OnRelease(c =>
                   {
                       c.SubmitChanges();
                       c.Dispose();
                   })
                   .As<DerpUniversityDataContext>()
                   .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof (IDomainService).Assembly)
                   .Where(t => t.IsAssignableTo<IDomainService>())
                   .Where(t => !t.IsAbstract)
                   .Where(t => !t.IsInterface)
                   .InstancePerLifetimeScope()
                   .AsImplementedInterfaces();

            _containerProvider = new ContainerProvider(builder.Build());
        }
    }
}