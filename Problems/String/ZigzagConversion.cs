using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Problems.String
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
            if (numRows == 1)
            {
                return s;
            }

            var stringBuilder = new StringBuilder(s.Length);
            
            var zigZagSize = numRows * 2 - 2;
            for (var i = 0; i < numRows; i++)
            {
                if (i == 0 || i == numRows - 1)
                {
                    for (var j = i; j < s.Length; j += zigZagSize)
                    {
                        stringBuilder.Append(s[j]);
                    }

                    continue;
                }

                var step = i * 2;
                for (var j = i; j < s.Length; j += step)
                {
                    stringBuilder.Append(s[j]);
                    step = zigZagSize - step;
                }
            }

            return stringBuilder.ToString();
        }

        [TestCaseSource(nameof(TestCases))]
        public string Leetcode_SortByRow(string s, int numRows)
        {
            if (numRows == 1)
            {
                return s;
            }

            var rowCount = Math.Min(numRows, s.Length);
            var rowStrings = new StringBuilder?[rowCount];
            var i = 0;
            var isGoingDown = false;

            foreach (var symbol in s)
            {
                if (i == 0 || i == numRows - 1)
                {
                    isGoingDown = !isGoingDown;
                }

                rowStrings[i] ??= new StringBuilder(s.Length);

                rowStrings[i]!.Append(symbol);

                i += isGoingDown ? 1 : -1;
            }

            var stringBuilder = new StringBuilder(s.Length);
            foreach (var rowString in rowStrings)
            {
                stringBuilder.Append(rowString);
            }

            return stringBuilder.ToString();
        }

        [TestCaseSource(nameof(TestCases))]
        public string Leetcode_VisitByRow(string s, int numRows)
        {
            if (numRows == 1)
            {
                return s;
            }

            var stringBuilder = new StringBuilder(s.Length);

            var zigZagSize = numRows * 2 - 2;
            for (var i = 0; i < numRows; i++)
            {
                for (var j = 0; i + j < s.Length; j += zigZagSize)
                {
                    stringBuilder.Append(s[i + j]);
                    if (i != 0 && i != numRows - 1 && j + zigZagSize - i < s.Length)
                    {
                        stringBuilder.Append(s[j + zigZagSize - i]);
                    }
                }
            }

            return stringBuilder.ToString();
        }
    }
}
