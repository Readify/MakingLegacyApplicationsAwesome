using System;

namespace MLAA.Web
{
    public static class GlobalConstants
    {
        public static Guid CurrentStudentId
        {
            get { return new Guid("F49E760B-38A9-4F6C-9B12-3B53C4B829EF"); }
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
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}