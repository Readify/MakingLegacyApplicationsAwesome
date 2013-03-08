using System;

namespace MLAA.Web
{
    public static class GlobalConstants
    {
        public static int CurrentStudentId
        {
            get { return 1; }
        }

        public static class Authentication
        {
            public static User CurrentUser
            {
                get
                {
                    return new User
                    {
                        UserId = CurrentStudentId,
                        Username = "fredflintstone",
                        FirstName = "Fred",
                        LastName = "Flintstone",
                    };
                }
            }
        }
    }

    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}