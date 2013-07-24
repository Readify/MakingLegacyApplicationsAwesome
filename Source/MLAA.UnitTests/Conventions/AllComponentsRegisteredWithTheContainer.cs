using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Autofac;
using MLAA.Web;
using NUnit.Framework;
using Shouldly;

namespace MLAA.UnitTests.Conventions
{
    [TestFixture]
    [Ignore]
    public class AllComponentsRegisteredWithTheContainer
    {
        [Test]
        public void MustBeAbleToBeResolved()
        {
            Assert.Inconclusive();
        }
    }

    [TestFixture]
    public class AllPages
    {
        [Test]
        [TestCaseSource("TestCases")]
        public void ShouldInheritBasePage(Type pageType)
        {
            pageType
                .IsClosedTypeOf(typeof (BasePage<>))
                .ShouldBe(true);
        }

        public IEnumerable<TestCaseData> TestCases()
        {
            return typeof (WebForm1)
                .Assembly
                .GetExportedTypes()
                .Where(t => t.IsAssignableTo<Page>())
                .Where(t => !t.IsAbstract)
                .Select(t => new TestCaseData(t)
                                 .SetName(t.FullName)
                )
                .ToArray();
        }
    }

    [TestFixture]
    public class EveryPage
    {
        [Test]
        [TestCaseSource("TestCases")]
        public void ShouldHaveAViewModelOfTheAppropriateName(Type pageType)
        {
            //FIXME this doesn't traverse the entire hierarchy.
            var genericBaseType = pageType.BaseType;
            var viewModelType = genericBaseType.GetGenericArguments().Single();

            viewModelType.Name.ShouldStartWith(pageType.Name);
        }

        public IEnumerable<TestCaseData> TestCases()
        {
            return typeof (WebForm1)
                .Assembly
                .GetExportedTypes()
                .Where(t => t.IsClosedTypeOf(typeof (BasePage<>)))
                .Select(t => new TestCaseData(t)
                                 .SetName(t.FullName)
                )
                .ToArray();
        }
    }

    [TestFixture]
    [Ignore]
    public class AllViewModels
    {
        [Test]
        [TestCaseSource("TestCases")]
        public void ShouldOnlyEverDependOnAbstractions(Type viewModelType)
        {
            var constructorInfo = viewModelType.GetConstructors().Single();
            var constructorParameters = constructorInfo.GetParameters();
            foreach (var p in constructorParameters)
            {
                p.ParameterType.IsInterface.ShouldBe(true);
            }
        }

        public IEnumerable<TestCaseData> TestCases()
        {
            return from c in typeof (_DefaultViewModel)
                       .Assembly
                       .GetExportedTypes()
                       .Where(t => t.Name.EndsWith("ViewModel"))
                       .Select(t => t.GetConstructors().Single())
                   from p in c.GetParameters()
                   select new TestCaseData(p)
                       .SetName(
                           string.Format("{0}({1} {2})",
                                         c.DeclaringType.FullName,
                                         p.ParameterType.Name,
                                         p.Name));
        }
    }
}