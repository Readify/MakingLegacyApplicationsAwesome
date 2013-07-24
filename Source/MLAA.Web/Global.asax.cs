using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Web;
using System.Web.Optimization;
using MLAA.Data.Linq2Sql;
using MLAA.Database;

/// <summary>
/// 
/// </summary>
namespace MLAA.Web
{
    /// <summary>
    /// 
    /// </summary>
    public class Global : HttpApplication
    {
        /// <summary>
        /// Code that runs on application startup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Start(object sender, EventArgs e)
        {
            DatabaseUpgrader.Upgrade(
                ConfigurationManager.ConnectionStrings["DerpUniversityConnectionString"].ConnectionString);

            DomainEvents.SetEventBrokerStrategy(new LyingCheatingEventBrokerThatDoesNothing());

            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

       /// <summary>
        /// Code that runs on application startup
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
            var sql = "SELECT * FROM Email";
            var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DerpUniversityConnectionString"].ConnectionString);
            connection.Open();
            var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var recipient = (string) reader.GetValue(1);
                var from = (string) reader.GetValue(0);
                var subject = (string) reader.GetValue(2);
                var body = (string) reader.GetValue(3);

                var smtpClient = new SmtpClient("localhost");
                try
                {
                    smtpClient.Send(new MailMessage(from, recipient, subject, body));
                }
                catch
                {
                    goto TrYAGainLater;
                }

            }
            connection.Close();

            connection.Open();
            var sql2 = "DELETE FROM Email";
            var command2 = new SqlCommand(sql2, connection);
            command2.ExecuteNonQuery();

        TrYAGainLater:
            ;
        }
    }
}