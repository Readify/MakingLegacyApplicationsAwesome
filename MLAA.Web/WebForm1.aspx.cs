using System;
using System.Collections.Generic;
using System.Configuration;
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
            var sql = "SELECT COUNT(*) FROM StudentSubjectEnrolment WHERE StudentId = " + GlobalConstants.Authentication.CurrentUser.UserId;
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
            string id = ((HiddenField)Repeater1.Items[e.Item.ItemIndex].FindControl("hiddenId")).Value;

            var sql = "INSERT INTO StudentSubjectEnrolment (StudentId, SubjectId) VALUES (" + GlobalConstants.Authentication.CurrentUser.UserId + ", " + id + ")";

            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DerpUniversityConnectionString"].ConnectionString);
            connection.Open();
            var command = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }
    }
}