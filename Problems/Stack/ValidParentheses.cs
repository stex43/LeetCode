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
                .Returns(true);

            yield return new TestCaseData("}")
                .SetName("{a} {m}")
                .Returns(false);

            yield return new TestCaseData("(((((())))))")
                .SetName("{a} {m}")
                .Returns(true);

            yield return new TestCaseData("(((((((()")
                .SetName("{a} {m}")
                .Returns(false);

            yield return new TestCaseData("((()(())))")
                .SetName("{a} {m}")
                .Returns(true);
        }

        [TestCaseSource(nameof(TestCases))]
        public bool Mine_First(string s)
        {
            var parenthesesMap = new Dictionary<char, char>
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' }
            };

            var stack = new Stack<char>(s.Length);
            foreach (var symbol in s)
            {
                if (parenthesesMap.ContainsKey(symbol))
                {
                    stack.Push(symbol);
                    continue;
                }

                if (!stack.TryPop(out var peek) || symbol != parenthesesMap[peek])
                {
                    return false;
                }
            }

            return stack.Count == 0;
        }
    }
}
