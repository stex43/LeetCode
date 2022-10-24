using System.Collections.Generic;
using NUnit.Framework;

namespace Problems.String
{
    [TestFixture]
    public sealed class IsSubsequence
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData("abc", "ahbgc")
                .SetName("{a} {m}")
                .Returns(true);

            yield return new TestCaseData("axc", "ahbgc")
                .SetName("{a} {m}")
                .Returns(false);

            yield return new TestCaseData("abc", "ahcgb")
                .SetName("{a} {m}")
                .Returns(false);

            yield return new TestCaseData("", "ahcgb")
                .SetName("{a} {m}")
                .Returns(true);
        }

        [TestCaseSource(nameof(TestCases))]
        public bool Mine_First(string s, string t)
        {
            var sIndex = 0;

            for (var tIndex = 0; tIndex < t.Length; tIndex++)
            {
                if (sIndex == s.Length)
                {
                    return true;
                }

                if (s[sIndex] == t[tIndex])
                {
                    sIndex++;
                }
            }

            return sIndex == s.Length;
        }
    }
}
