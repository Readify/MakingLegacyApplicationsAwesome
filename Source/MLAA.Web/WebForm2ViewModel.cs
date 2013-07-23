using MLAA.Data.Linq2Sql;

namespace MLAA.Web
{
    public class WebForm2ViewModel
    {
        public WebForm2ViewModel()
        {
            Students = EnrolmentManager.SearchStudents("");
        }

        public Student[] Students { get; set; }
    }
}