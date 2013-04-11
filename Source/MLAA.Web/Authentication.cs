using System;

namespace MLAA.Web
{
    /// <summary>
    /// 
    /// </summary>
    public static class GlobalConstants
    {
        /// <summary>
        /// 
        /// </summary>
        public static int CurrentStudentId
        {
            get { return 1; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class Authentication
    {
        /// <summary>
        /// 
        /// </summary>
        public static User CurrentUser
        {
            get
            {
                return new User
                {
                    UserId = GlobalConstants.CurrentStudentId,
                    Username = "fredflintstone",
                    FirstName = "Fred",
                    LastName = "Flintstone",
                };
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}