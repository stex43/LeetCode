using System.Collections.Generic;
using NUnit.Framework;

namespace Problems.Arrays
{
    public class BinarySearch
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData(new[] { -1, 0, 3, 5, 9, 12 }, 9)
                .SetName("{a} {m}")
                .Returns(4);

            yield return new TestCaseData(new[] { -1, 0, 3, 5, 9, 12 }, 2)
                .SetName("{a} {m}")
                .Returns(-1);

            yield return new TestCaseData(new[] { 2, 5 }, 0)
                .SetName("{a} {m}")
                .Returns(-1);
            
            yield return new TestCaseData(new[] { 2, 5 }, 6)
                .SetName("{a} {m}")
                .Returns(-1);
            
            yield return new TestCaseData(new[] { 5 }, 5)
                .SetName("{a} {m}")
                .Returns(0);
        }

        [TestCaseSource(nameof(TestCases))]
        public int Mine_Recursive(int[] nums, int target)
        {
            return Search(nums, target, 0, nums.Length - 1);
        }

        private static int Search(int[] nums, int target, int left, int right)
        {
            if (left > right)
            {
                return -1;
            }
            
            var middle = (left + right) / 2;

            if (nums[middle] == target)
            {
                return middle;
            }

            if (nums[middle] > target)
            {
                return Search(nums, target, left, middle - 1);
            }
            
            return Search(nums, target, middle + 1, right);
        }
        
        [TestCaseSource(nameof(TestCases))]
        public int Mine_Iterative(int[] nums, int target)
        {
            var left = 0;
            var right = nums.Length - 1;
            while (left <= right)
            {
                var middle = (left + right) / 2;

                if (nums[middle] == target)
                {
                    return middle;
                }

                if (nums[middle] > target)
                {
                    right = middle - 1;
                    continue;
                }

                left = middle + 1;
            }

            return -1;
        }
    }
}