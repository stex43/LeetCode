using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Problems
{
    [TestFixture]
    public sealed class ZigzagConversion
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData("PAYPALISHIRING", 3)
                .SetName("{a} {m}")
                .Returns("PAHNAPLSIIGYIR");

            yield return new TestCaseData("PAYPALISHIRING", 4)
                .SetName("{a} {m}")
                .Returns("PINALSIGYAHRPI");

            yield return new TestCaseData("A", 1)
                .SetName("{a} {m}")
                .Returns("A");
        }

        [TestCaseSource(nameof(TestCases))]
        public string Mine_First(string s, int numRows)
        {
            var stringBuilder = new StringBuilder(s.Length);
            for (var i = 0; i < numRows; i++)
            {
                if (i == 0 || i == numRows - 1)
                {
                    var j = i;

                    while (j < s.Length)
                    {
                        stringBuilder.Append(s[j]);
                        j += numRows - 2;
                    }
                }
            }

            return string.Empty;
        }
    }
}
