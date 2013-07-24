using System.Web;
using System.Web.UI;
using Autofac;
using Autofac.Integration.Web;

namespace MLAA.Web
{
    public abstract class BasePage<TViewModel> : Page
    {
        public TViewModel ViewModel { get; set; }

        protected BasePage()
        {
            var cpa = (IContainerProviderAccessor) HttpContext.Current.ApplicationInstance;
            var cp = cpa.ContainerProvider;
            cp.RequestLifetime.InjectUnsetProperties(this);
        }
    }
}