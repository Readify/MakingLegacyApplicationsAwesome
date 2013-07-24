using System;
using System.Collections.Generic;
using System.Linq;
using MLAA.Web;
using NUnit.Framework;
using Shouldly;

namespace MLAA.UnitTests.Conventions
{
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