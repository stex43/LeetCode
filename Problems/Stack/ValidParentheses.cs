using System.Collections.Generic;
using NUnit.Framework;

namespace Problems.Stack
{
    [TestFixture]
    public sealed class ValidParentheses
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData("()")
                .SetName("{a} {m}")
                .Returns(true);

            yield return new TestCaseData("()[]{}")
                .SetName("{a} {m}")
                .Returns(true);

            yield return new TestCaseData("(]")
                .SetName("{a} {m}")
                .Returns(false);

            yield return new TestCaseData("([)]")
                .SetName("{a} {m}")
                .Returns(false);

            yield return new TestCaseData("{[]}")
                .SetName("{a} {m}")
                .Returns(false);
        }

        [TestCaseSource(nameof(TestCases))]
        public bool Mine_First(string s)
        {
            var openings = new HashSet<char>(new[] { '(', '[', '{' });
            var closings = new HashSet<char>(new[] { ')', ']', '}' });

            var stack = new Stack<char>(s.Length);
            foreach (var symbol in s)
            {

            }
            return false;
        }
    }
}
