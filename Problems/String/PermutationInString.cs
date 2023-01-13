using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Problems.String
{
    [TestFixture]
    public sealed class PermutationInString
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData("ab", "eidbaooo")
                .SetName("{a} {m}")
                .Returns(true);
            
            yield return new TestCaseData("ab", "eidboaoo")
                .SetName("{a} {m}")
                .Returns(false);
            
            yield return new TestCaseData("adc", "dcda")
                .SetName("{a} {m}")
                .Returns(true);
        }

        [TestCaseSource(nameof(TestCases))]
        public bool Mine_First(string s1, string s2)
        {
            var charsTracking = new Dictionary<char, int>();
            foreach (var c in s1)
            {
                if (!charsTracking.ContainsKey(c))
                {
                    charsTracking[c] = 0;
                }

                charsTracking[c]++;
            }

            var left = 0;

            foreach (var c in s2)
            {
                if (!charsTracking.ContainsKey(c))
                {
                    charsTracking[c] = 0;
                }

                charsTracking[c]--;

                while (charsTracking[c] == -1)
                {
                    charsTracking[s2[left]]++;
                    left++;
                }
                
                if (charsTracking.Values.All(x => x == 0))
                {
                    return true;
                }
            }

            return false;
        }

        [TestCaseSource(nameof(TestCases))]
        public bool Mine_Second(string s1, string s2)
        {
            if (s1.Length > s2.Length)
            {
                return false;
            }
            
            var charsTracking = new Dictionary<char, int>();
            foreach (var c in s1)
            {
                if (!charsTracking.ContainsKey(c))
                {
                    charsTracking[c] = 0;
                }

                charsTracking[c]++;
            }

            var left = 0;

            for (var right = 0; right < s2.Length; right++)
            {
                var c = s2[right];
                
                if (!charsTracking.ContainsKey(c))
                {
                    charsTracking[c] = 0;
                }

                charsTracking[c]--;

                if (right - left + 1 > s1.Length)
                {
                    charsTracking[s2[left++]]++;
                }
                
                if (charsTracking.Values.All(x => x == 0))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
