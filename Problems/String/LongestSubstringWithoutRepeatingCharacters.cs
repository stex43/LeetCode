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
                .Returns(1);

            yield return new TestCaseData("pwwkew")
                .SetName("{a} {m}")
                .Returns(3);

            yield return new TestCaseData("")
                .SetName("{a} {m}")
                .Returns(0);

            yield return new TestCaseData("abcde")
                .SetName("{a} {m}")
                .Returns(5);

            yield return new TestCaseData("abba")
                .SetName("{a} {m}")
                .Returns(2);

            yield return new TestCaseData("wabba")
                .SetName("{a} {m}")
                .Returns(3);
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
                while (set.Contains(s[right]))
                {
                    set.Remove(s[left]);
                    left++;
                }

                maxLength = Math.Max(maxLength, right - left + 1);

                if (!set.Contains(s[right]))
                {
                    set.Add(s[right]);
                }

                right++;
            }

            return maxLength;
        }

        [TestCaseSource(nameof(TestCases))]
        public int Leetcode_Dictionary(string s)
        {
            var chars = new Dictionary<char, int>(s.Length);

            var left = 0;
            var maxLength = 0;

            for (var right = 0; right < s.Length; right++)
            {
                if (chars.ContainsKey(s[right]))
                {
                    left = Math.Max(left, chars[s[right]] + 1);
                }

                maxLength = Math.Max(maxLength, right - left + 1);
                chars[s[right]] = right;
            }

            return maxLength;
        }

        [TestCaseSource(nameof(TestCases))]
        public int Leetcode_BruteForce(string s)
        {
            var maxLength = 0;

            for (var i = 0; i < s.Length; i++)
            {
                for (var j = i; j < s.Length; j++)
                {
                    var substring = s.Substring(i, j - i + 1);
                    var set = new HashSet<char>(substring);

                    if (substring.Length == set.Count)
                    {
                        maxLength = Math.Max(substring.Length, maxLength);
                    }
                }
            }

            return maxLength;
        }
    }
}
