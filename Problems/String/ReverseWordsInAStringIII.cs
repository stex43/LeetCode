using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Problems.String
{
    [TestFixture]
    public sealed class ReverseWordsInAStringIII
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData("Let's take LeetCode contest")
                .SetName("{a} {m}")
                .Returns("s'teL ekat edoCteeL tsetnoc");
            
            yield return new TestCaseData("God Ding")
                .SetName("{a} {m}")
                .Returns("doG gniD");
        }

        [TestCaseSource(nameof(TestCases))]
        public string Mine_First(string s)
        {
            var reversedWords = s
                .Split(' ')
                .Select(x => x.Reverse().ToArray())
                .Select(x => new string(x));
            
            return string.Join(' ', reversedWords);
        }

        [TestCaseSource(nameof(TestCases))]
        public string Mine_Second(string s)
        {
            var stringBuilder = new StringBuilder(s.Length);

            var left = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] != ' ' && i != s.Length - 1)
                {
                    continue;
                }

                var right = s[i] == ' ' ? i - 1 : i;

                while (left <= right)
                {
                    stringBuilder.Append(s[right]);
                    right--;
                }

                if (s[i] == ' ')
                {
                    stringBuilder.Append(' ');
                }

                left = i + 1;
            }

            return stringBuilder.ToString();
        }
    }
}
