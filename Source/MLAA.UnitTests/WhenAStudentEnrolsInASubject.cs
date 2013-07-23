using MLAA.Data.Linq2Sql;
using NUnit.Framework;
using Shouldly;

namespace MLAA.UnitTests
{
    [TestFixture]
    public class WhenAStudentEnrolsInASubject
    {
        private Student _fred;
        private Subject _law;

        [SetUp]
        public void SetUp()
        {
            _fred = new Student();
            _law = new Subject();

            // Act
            _fred.EnrolIn(_law);
        }

        [Test]
        public void TheStudentShouldBeEnrolledInTheSubject()
        {
            // Assert
            _fred.IsEnrolledIn(_law).ShouldBe(true);
        }
    }
}