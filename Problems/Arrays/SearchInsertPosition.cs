using System.Collections.Generic;
using NUnit.Framework;

namespace Problems.Arrays
{
    public sealed class SearchInsertPosition
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData(new[] { 1, 3, 5, 6 }, 5)
                .SetName("{a} {m}")
                .Returns(2);
            
            yield return new TestCaseData(new[] { 1, 3, 5, 6 }, 2)
                .SetName("{a} {m}")
                .Returns(1);
            
            yield return new TestCaseData(new[] { 1, 3, 5, 6 }, 7)
                .SetName("{a} {m}")
                .Returns(4);
            
            yield return new TestCaseData(new[] { -1, 0, 3, 5, 9, 12 }, 9)
                .SetName("{a} {m}")
                .Returns(4);

            yield return new TestCaseData(new[] { -1, 0, 3, 5, 9, 12 }, 2)
                .SetName("{a} {m}")
                .Returns(2);

            yield return new TestCaseData(new[] { 2, 5 }, 0)
                .SetName("{a} {m}")
                .Returns(0);
            
            yield return new TestCaseData(new[] { 2, 5 }, 6)
                .SetName("{a} {m}")
                .Returns(2);
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

            return left;
        }
    }
}