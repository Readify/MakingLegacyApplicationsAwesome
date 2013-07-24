using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MLAA.Web;
using NUnit.Framework;
using Shouldly;

namespace MLAA.UnitTests.Conventions
{
    [TestFixture]
    public class AllViewModels
    {
        [Test]
        [TestCaseSource("TestCases")]
        public void ShouldOnlyEverDependOnAbstractions(ParameterInfo parameterInfo)
        {
            parameterInfo.ParameterType.IsInterface.ShouldBe(true);
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