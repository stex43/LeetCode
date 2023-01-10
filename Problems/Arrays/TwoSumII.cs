using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Problems.Arrays
{
    [TestFixture]
    public sealed class TwoSumII
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData(new[] { 2, 7, 11, 15 }, 9)
                .SetName("{a} {m}")
                .Returns(new[] { 1, 2 });

            yield return new TestCaseData(new[] { 2, 3, 4 }, 6)
                .SetName("{a} {m}")
                .Returns(new[] { 1, 3 });

            yield return new TestCaseData(new[] { -1, 0 }, -1)
                .SetName("{a} {m}")
                .Returns(new[] { 1, 2 });
        }

        [TestCaseSource(nameof(TestCases))]
        public int[] Mine_First_BinarySearch(int[] numbers, int target)
        {
            for (var i = 0; i < numbers.Length; i++)
            {
                var left = i + 1;
                var right = numbers.Length - 1;

                while (left <= right)
                {
                    var middle = (left + right) / 2;
                    
                    var sum = numbers[i] + numbers[middle];
                    
                    if (sum == target)
                    {
                        return new[] { i + 1, middle + 1 };
                    }

                    if (sum > target)
                    {
                        right = middle - 1;
                        continue;
                    }

                    left = middle + 1;
                }
            }

            return Array.Empty<int>();
        }

        [TestCaseSource(nameof(TestCases))]
        public int[] Mine_Second_TwoPointers(int[] numbers, int target)
        {
            var left = 0;
            var right = numbers.Length - 1;

            while (true)
            {
                var sum = numbers[left] + numbers[right];

                if (sum > target)
                {
                    right--;
                    continue;
                }

                if (sum < target)
                {
                    left++;
                    continue;
                }
                
                return new[] { left + 1, right + 1 };
            }
        }
    }
}
