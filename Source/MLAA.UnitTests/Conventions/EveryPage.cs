using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using MLAA.Web;
using NUnit.Framework;
using Shouldly;

namespace MLAA.UnitTests.Conventions
{
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
}