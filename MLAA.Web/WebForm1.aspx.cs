using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MLAA.Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var sql = "SELECT COUNT(*) FROM StudentSubjectEnrolment WHERE StudentId = " + Authentication.CurrentUser.UserId;
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DerpUniversityConnectionString"].ConnectionString);
            connection.Open();
            var command = new SqlCommand(sql, connection);
            var result = (int)command.ExecuteScalar();

            label1.Text = result.ToString();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            DataBind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string strId = ((HiddenField)Repeater1.Items[e.Item.ItemIndex].FindControl("hiddenId")).Value;

            string sql;
            int subjectId;
            int.TryParse(strId, out subjectId);
            if (EnrolmentManager.IsEnrolled(Authentication.CurrentUser.UserId, subjectId))
            {
                sql = "DELETE FROM StudentSubjectEnrolment WHERE StudentId=" + Authentication.CurrentUser.UserId + " AND SubjectId=" + strId;
            }
            else
            {
                sql = "INSERT INTO StudentSubjectEnrolment (StudentId, SubjectId) VALUES (" + Authentication.CurrentUser.UserId + ", " + strId + ")";
            }

            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DerpUniversityConnectionString"].ConnectionString);
            connection.Open();
            var command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var item = (RepeaterItem) e.Item;
            var dataRowView = (DataRowView) item.DataItem;
            
            var button = (Button)e.Item.FindControl("Button1");
            int subjectId = (int)dataRowView["Id"];

            if (EnrolmentManager.IsEnrolled(Authentication.CurrentUser.UserId, subjectId))
            {
                button.Text = "Cancel enrolment";
            }
        }
    }

    public static class EnrolmentManager
    {
        public static bool IsEnrolled(int studentId, int subjectId)
        {
            var sql = "SELECT COUNT(*) FROM StudentSubjectEnrolment WHERE StudentId = " + Authentication.CurrentUser.UserId + " AND SubjectId='"+subjectId+"'";
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DerpUniversityConnectionString"].ConnectionString);
            connection.Open();
            var command = new SqlCommand(sql, connection);
            var result = (int)command.ExecuteScalar();
            if (result > 0) return true;
            return false;
        }
    }
}