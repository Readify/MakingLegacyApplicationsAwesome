using System;

namespace MLAA.Web
{
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
}