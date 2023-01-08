using System.Collections.Generic;
using NUnit.Framework;

namespace Problems.Arrays
{
    [TestFixture]
    public sealed class RotateArray
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData(new[] { 1, 2, 3, 4, 5, 6, 7 }, 3)
                .SetName("{a} {m}")
                .Returns(new[] { 5, 6, 7, 1, 2, 3, 4 });

            yield return new TestCaseData(new[] { -1, -100, 3, 99 }, 2)
                .SetName("{a} {m}")
                .Returns(new[] { 3, 99, -1, -100 });
            
            yield return new TestCaseData(new[] { -1 }, 2)
                .SetName("{a} {m}")
                .Returns(new[] { -1 });
            
            yield return new TestCaseData(new[] { 1, 2 }, 3)
                .SetName("{a} {m}")
                .Returns(new[] { 2, 1 });
        }

        [TestCaseSource(nameof(TestCases))]
        public int[] Mine_First(int[] nums, int k)
        {
            var result = new int[nums.Length];
            k = k % nums.Length;

            for (var i = nums.Length - k; i < nums.Length; i++)
            {
                result[i - nums.Length + k] = nums[i];
            }
            
            for (var i = 0; i < nums.Length - k; i++)
            {
                result[i + k] = nums[i];
            }

            for (var i = 0; i < nums.Length; i++)
            {
                nums[i] = result[i];
            }
            return nums;
        }

        [TestCaseSource(nameof(TestCases))]
        public int[] Mine_Second(int[] nums, int k)
        {
            var result = new int[nums.Length];
            k = k % nums.Length;

            for (var i = 0; i < nums.Length; i++)
            {
                result[(i + k) % nums.Length] = nums[i];
            }

            for (var i = 0; i < nums.Length; i++)
            {
                nums[i] = result[i];
            }
            return nums;
        }

        [TestCaseSource(nameof(TestCases))]
        public int[] Leetcode_ReverseParts(int[] nums, int k)
        {
            if (nums.Length == 1)
            {
                return nums;
            }

            k = k % nums.Length;
            Reverse(nums, 0, nums.Length - 1);
            Reverse(nums, 0, k - 1);
            Reverse(nums, k, nums.Length - 1);
            
            return nums;
        }

        private static void Reverse(int[] nums, int i, int j)
        {
            for (var k = i; k <= (i + j) / 2; k++)
            {
                (nums[k], nums[j - (k - i)]) = (nums[j - (k - i)], nums[k]);
            }
        }
    }
}
