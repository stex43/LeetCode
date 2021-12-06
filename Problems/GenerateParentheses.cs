using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Problems
{
    [TestFixture]
    public sealed class GenerateParentheses
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData(2)
                .SetName("{a} {m}")
                .Returns(new TestUnorderedCollection<string> { "(())", "()()" });

            yield return new TestCaseData(3)
                .SetName("{a} {m}")
                .Returns(new TestUnorderedCollection<string> { "((()))", "(()())", "(())()", "()(())", "()()()" });

            yield return new TestCaseData(1)
                .SetName("{a} {m}")
                .Returns(new TestUnorderedCollection<string> { "()" });
        }

        #region Mine

        [TestCaseSource(nameof(TestCases))]
        public List<string> Mine_First(int n)
        {
            if (n == 0)
            {
                return new List<string> { string.Empty };
            }

            var availableParentheses = new Dictionary<char, int>
            {
                { '(', n },
                { ')', n }
            };

            var result = new List<string>();
            var combination = new char[n * 2];
            GetCombinations(combination, availableParentheses, 0, result);

            return result;
        }

        private void GetCombinations(char[] combination, Dictionary<char, int> availableParentheses, int currentPosition, List<string> result)
        {
            if (currentPosition == combination.Length)
            {
                result.Add(string.Join(string.Empty, combination));
                return;
            }

            if (availableParentheses['('] > 0)
            {
                combination[currentPosition] = '(';
                availableParentheses['(']--;
                GetCombinations(combination, availableParentheses, currentPosition + 1, result);

                availableParentheses['(']++;
            }

            if (availableParentheses[')'] - 1 >= availableParentheses['('])
            {
                combination[currentPosition] = ')';
                availableParentheses[')']--;
                GetCombinations(combination, availableParentheses, currentPosition + 1, result);

                availableParentheses[')']++;
            }
        }

        #endregion

        #region Leetcode_Backtrack

        [TestCaseSource(nameof(TestCases))]
        public List<string> Leetcode_Backtrack(int n)
        {
            if (n == 0)
            {
                return new List<string> { string.Empty };
            }

            var result = new List<string>();
            GetCombinations(new StringBuilder(2 * n), result, 0, 0, n);

            return result;
        }

        private void GetCombinations(StringBuilder stringBuilder, List<string> result, int open, int close, int max)
        {
            if (stringBuilder.Length == max * 2)
            {
                result.Add(stringBuilder.ToString());
                return;
            }

            if (open < max)
            {
                stringBuilder.Append('(');
                GetCombinations(stringBuilder, result, open + 1, close, max);

                stringBuilder.Remove(stringBuilder.Length - 1, 1);
            }

            if (close < open)
            {
                stringBuilder.Append(')');
                GetCombinations(stringBuilder, result, open, close + 1, max);

                stringBuilder.Remove(stringBuilder.Length - 1, 1);
            }
        }

        #endregion

        #region Leetcode_BruteForce

        [TestCaseSource(nameof(TestCases))]
        public List<string> Leetcode_BruteForce(int n)
        {
            if (n == 0)
            {
                return new List<string> { string.Empty };
            }

            var result = new List<string>();
            GetCombinations(new StringBuilder(), result, n);

            return result;
        }

        private void GetCombinations(StringBuilder stringBuilder, List<string> result, int max)
        {
            if (stringBuilder.Length == max * 2)
            {
                if (IsRight(stringBuilder))
                {
                    result.Add(stringBuilder.ToString());
                }

                return;
            }

            stringBuilder.Append('(');
            GetCombinations(stringBuilder, result, max);
            stringBuilder.Remove(stringBuilder.Length - 1, 1);

            stringBuilder.Append(')');
            GetCombinations(stringBuilder, result, max);
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
        }

        private bool IsRight(StringBuilder combination)
        {
            var balance = 0;
            for (var i = 0; i < combination.Length; i++)
            {
                var symbol = combination[i];

                if (symbol == '(')
                {
                    balance++;
                    continue;
                }

                balance--;
                if (balance < 0)
                {
                    return false;
                }
            }

            return balance == 0;
        }

        #endregion

        [TestCaseSource(nameof(TestCases))]
        public List<string> Leetcode_ClosureNumber(int n)
        {
            var result = new List<string>();

            if (n == 0)
            {
                result.Add("");
            }
            else
            {
                for (var c = 0; c <= n - 1; c++)
                {
                    foreach (var left in Leetcode_ClosureNumber(c))
                    {
                        foreach (var right in Leetcode_ClosureNumber(n - 1 - c))
                        {
                            result.Add("(" + left + ")" + right);
                        }
                    }
                }
            }
            
            return result;
        }
    }
}
