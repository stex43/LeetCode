using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Problems.String
{
    [TestFixture]
    public sealed class LongestSubstringWithoutRepeatingCharacters
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData("abcabcbb")
                .SetName("{a} {m}")
                .Returns(3);

            yield return new TestCaseData("bbbbb")
                .SetName("{a} {m}")
                .Returns(1); ;

            yield return new TestCaseData("pwwkew")
                .SetName("{a} {m}")
                .Returns(3); ;

            yield return new TestCaseData("")
                .SetName("{a} {m}")
                .Returns(0); ;

            yield return new TestCaseData("abcde")
                .SetName("{a} {m}")
                .Returns(5); ;
        }

        [TestCaseSource(nameof(TestCases))]
        public int Mine_First(string s)
        {
            var set = new HashSet<char>(s.Length);

            var left = 0;
            var right = 0;
            var maxLength = 0;

            while (right < s.Length)
            {
                if (!set.Contains(s[right]))
                {
                    set.Add(s[right]);
                    right++;
                    continue;
                }

                maxLength = Math.Max(maxLength, right - left);

                while (s[left] != s[right])
                {
                    set.Remove(s[left]);
                    left++;
                }

                right++;
                left++;
            }

            return Math.Max(maxLength, right - left);
        }

        [TestCaseSource(nameof(TestCases))]
        public int Mine_Second(string s)
        {
            var chars = new Dictionary<char, int>();

            var left = 0;
            var right = 0;
            var maxLength = 0;

            while (right < s.Length)
            {
                var currentChar = s[right];

                if (!chars.ContainsKey(currentChar))
                {
                    chars[currentChar] = right;
                    right++;
                    continue;
                }

                maxLength = Math.Max(maxLength, right - left);

                left = chars[currentChar] + 1;
                chars[currentChar] = right;

                right++;
            }

            return Math.Max(maxLength, right - left);
        }
    }
}
