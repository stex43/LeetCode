using System.Collections.Generic;
using NUnit.Framework;

namespace Problems
{
    [TestFixture]
    public sealed class Template
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData()
                .SetName("{a} {m}")
                .Returns(0);
        }

        [TestCaseSource(nameof(TestCases))]
        public int Mine_First()
        {
            return 0;
        }
    }
}
