using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Problems.Arrays
{
    public sealed class SquaresOfASortedArray
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData(new[] { -4, -1, 0, 3, 10 })
                .SetName("{a} {m}")
                .Returns(new[] { 0, 1, 9, 16, 100 });

            yield return new TestCaseData(new[] { -7, -3, 2, 3, 11 })
                .SetName("{a} {m}")
                .Returns(new[] { 4, 9, 9, 49, 121 });
            
            yield return new TestCaseData(new[] { 1 })
                .SetName("{a} {m}")
                .Returns(new[] { 1 });
            
            yield return new TestCaseData(new[] { -1, 0, 1 })
                .SetName("{a} {m}")
                .Returns(new[] { 0, 1, 1});
        }

        #region Mine_First
        
        [TestCaseSource(nameof(TestCases))]
        public int[] Mine_First(int[] nums)
        {
            var firstPositiveOrZero = FindFirstPositiveOrZero(nums, 0, nums.Length - 1);

            var left = firstPositiveOrZero - 1;
            var right = firstPositiveOrZero;
            var result = new List<int>(nums.Length);

            while (left >= 0 || right < nums.Length)
            {
                var leftValue = left >= 0 ? nums[left] : int.MaxValue;
                var rightValue = right < nums.Length ? nums[right] : int.MaxValue;
                
                if (Math.Abs(leftValue) <= Math.Abs(rightValue))
                {
                    result.Add(leftValue * leftValue);
                    left--;
                    continue;
                }
                
                result.Add(rightValue * rightValue);
                right++;
            }

            return result.ToArray();
        }

        private static int FindFirstPositiveOrZero(int[] nums, int left, int right)
        {
            if (left == right)
            {
                return left;
            }

            var middle = (left + right) / 2;

            if (nums[middle] >= 0)
            {
                return FindFirstPositiveOrZero(nums, left, middle);
            }

            return FindFirstPositiveOrZero(nums, middle + 1, right);
        }

        #endregion
        
        [TestCaseSource(nameof(TestCases))]
        public int[] Mine_Second(int[] nums)
        {
            var result = new int[nums.Length];

            var left = 0;
            var right = nums.Length - 1;
            var count = nums.Length - 1;
            
            while (left <= right)
            {
                var leftValue = nums[left];
                var rightValue = nums[right];
                if (Math.Abs(leftValue) < Math.Abs(rightValue))
                {
                    result[count] = rightValue * rightValue;
                    count--;
                    right--;
                    continue;
                }

                result[count] = leftValue * leftValue;
                count--;
                left++;
            }

            return result;
        }
    }
}