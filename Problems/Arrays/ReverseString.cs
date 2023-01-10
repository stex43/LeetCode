using System.Collections.Generic;
using NUnit.Framework;

namespace Problems.Arrays
{
    public sealed class ReverseString
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData(new[] { 'h', 'e', 'l', 'l', 'o' })
                .SetName("{a} {m}")
                .Returns(new[] { 'o', 'l', 'l', 'e', 'h' });
            
            yield return new TestCaseData(new[] { 'H', 'a', 'n', 'n', 'a', 'h' })
                .SetName("{a} {m}")
                .Returns(new[] { 'h', 'a', 'n', 'n', 'a', 'H' });
        }

        [TestCaseSource(nameof(TestCases))]
        public char[] Mine_First(char[] s)
        {
            var left = 0;
            var right = s.Length - 1;

            while (left < right)
            {
                (s[left], s[right]) = (s[right], s[left]);

                left++;
                right--;
            }

            return s;
        }
    }
}