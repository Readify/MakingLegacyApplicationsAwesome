using MLAA.Data.Linq2Sql;
using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace MLAA.UnitTests
{
    [TestFixture]
    public class WhenAStudentEnrolsInASubject
    {
        private Student _fred;
        private Subject _law;
        private IEventBroker _eventBroker;

        [SetUp]
        public void SetUp()
        {
            _eventBroker = Substitute.For<IEventBroker>();
            DomainEvents.SetEventBrokerStrategy(_eventBroker);

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

        [Test]
        public void ADomainEventShouldBeRaised()
        {
            _eventBroker.Received().Raise(Arg.Any<StudentEnrolledInSubjectEvent>());
        }
    }
}