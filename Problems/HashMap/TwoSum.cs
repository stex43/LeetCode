using System.Collections.Generic;
using NUnit.Framework;

namespace Problems.HashMap
{
    [TestFixture]
    public sealed class TwoSum
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData(new[] { 2, 7, 11, 15 }, 9)
                .SetName("{a}")
                .Returns(new[] { 0, 1 });

            yield return new TestCaseData(new[] { 3, 2, 4 }, 6)
                .SetName("{a}")
                .Returns(new[] { 1, 2 });

            yield return new TestCaseData(new[] { 3, 3 }, 6)
                .SetName("{a}")
                .Returns(new[] { 0, 1 });
        }

        [TestCaseSource(nameof(TestCases))]
        public int[] Mine_First(int[] nums, int target)
        {
            var map = new Dictionary<int, int>(nums.Length);
            for (var i = 0; i < nums.Length; i++)
            {
                var num = nums[i];

                if (map.TryGetValue(num, out var j))
                {
                    return new[] { j, i };
                }

                map[target - num] = i;
            }

            return null;
        }

        [TestCaseSource(nameof(TestCases))]
        public int[] Leetcode_BruteForce(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new[] { i, j };
                    }
                }
            }

            return null;
        }
    }
}
