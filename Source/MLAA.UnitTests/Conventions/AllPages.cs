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
                .Where(t => TypeExtensions.IsAssignableTo<Page>(t))
                .Where(t => !t.IsAbstract)
                .Select(t => new TestCaseData(t)
                                 .SetName(t.FullName)
                )
                .ToArray();
        }
    }
}