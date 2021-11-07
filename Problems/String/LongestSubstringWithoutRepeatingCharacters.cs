using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Problems.String
{
    [TestFixture]
    public sealed class LongestSubstringWithoutRepeatingCharacters
    {
        [Test]
        public void Test()
        {
            var s = "";

            var set = new HashSet<char>(s.Length);

            var left = 0;
            var right = 0;
            var maxLength = 0;

            while (left < s.Length)
            {
                if (!set.Contains(s[left]))
                {
                    set.Add(s[left]);
                    left++;
                    continue;
                }

                maxLength = Math.Max(maxLength, left - right);

                while (s[right] != s[left])
                {
                    set.Remove(s[right]);
                    right++;
                }

                left++;
                right++;
            }

            maxLength = Math.Max(maxLength, left - right);
        }
    }
}
