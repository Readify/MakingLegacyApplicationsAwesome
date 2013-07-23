using System.Web.UI;
using MLAA.Data.Linq2Sql;

namespace MLAA.Web
{
    public partial class WebForm2 : Page
    {
        public WebForm2ViewModel ViewModel { get; set; }

        public WebForm2()
        {
            ViewModel = new WebForm2ViewModel();
        }
    }

    public class WebForm2ViewModel
    {
        public WebForm2ViewModel()
        {
            Students = EnrolmentManager.SearchStudents("");
        }

        public Student[] Students { get; set; }
    }
}