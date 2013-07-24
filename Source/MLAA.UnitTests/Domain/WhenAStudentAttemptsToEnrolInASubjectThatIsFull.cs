using System;
using MLAA.Data.Linq2Sql;
using NUnit.Framework;

namespace MLAA.UnitTests.Domain
{
    [TestFixture]
    public class WhenAStudentAttemptsToEnrolInASubjectThatIsFull
    {
        [Test]
        [ExpectedException(typeof (InvalidOperationException))]
        public void TheyShouldNotBePermitted()
        {
            var fred = new Student();
            var law = new Subject
            {
                MaxStudents = 0,
            };

            fred.EnrolIn(law);

            Assert.Inconclusive("This is our mission for tomorrow morning. We need to add a non-default constructor to our entity so that we can reliably create instances in a valid state.");
        }
    }
}