using System.Web.UI;

namespace MLAA.Web
{
    public abstract class BasePage<TViewModel> : Page where TViewModel : new()
    {
        public TViewModel ViewModel { get; set; }

        protected BasePage()
        {
            ViewModel = new TViewModel();
        }
    }
}