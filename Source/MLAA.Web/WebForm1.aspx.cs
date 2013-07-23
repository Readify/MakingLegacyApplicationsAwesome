/* This code is copyright Derp University. All rights reserved.
 * 
 * NO REDISTRIBUTION IS PERMITTED WITHOUT THE WRITTEN AUTHORISATION OF DERP UNIVERSITY.
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

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
    using System;
    using System.Web;
    using System.Web.UI;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
   
    using System.Web.UI.WebControls;

    /// <summary>
    /// WebForm 1
    /// </summary>
    public partial class WebForm1 : System.Web.UI.Page
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            var sql = "SELECT COUNT(*) FROM StudentSubjectEnrolment WHERE StudentId = " + Authentication.CurrentUser.UserId;
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DerpUniversityConnectionString"].ConnectionString);
            connection.Open();
            var command = new SqlCommand(sql, connection);
            var result = (int)command.ExecuteScalar();

            label1.Text = result.ToString();
        }

        /// <summary>
        /// Happens after the page is rendered to the browser.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            DataBind();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string subject = ((HiddenField)Repeater1.Items[e.Item.ItemIndex].FindControl("hiddenId")).Value;

            string SQL;
            int SUBJECT;
            int.TryParse(subject, out SUBJECT);
            if (EnrolmentManager.IsEnrolled(Authentication.CurrentUser.UserId, SUBJECT))
            {
                SQL = "DELETE FROM StudentSubjectEnrolment WHERE StudentId=" + Authentication.CurrentUser.UserId + " AND SubjectId=" + subject;
            }
            else
            {
                SQL = "INSERT INTO StudentSubjectEnrolment (StudentId, SubjectId) VALUES (" + Authentication.CurrentUser.UserId + ", " + subject + ")";
            }

            // not sure how this works but it was on stack overflow
                        var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DerpUniversityConnectionString"].ConnectionString);
                        connection.Open();
                        var command = new SqlCommand(SQL, connection);
                        command.ExecuteNonQuery();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
               /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
         protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                var item = (RepeaterItem) e.Item;
                var dataRowView = (DataRowView) item.DataItem;

                var BUTTON1 = (Button) e.Item.FindControl("Button1");
                int subjectId = (int) dataRowView["Id"];

                if (EnrolmentManager.IsEnrolled(Authentication.CurrentUser.UserId, subjectId))
                {
                    BUTTON1.Text = "Cancel enrolment";
                }
            }
            catch(Exception E)
            {
                throw E;
            }
        }
    }
}