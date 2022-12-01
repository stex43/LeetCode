using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Problems.Arrays
{
    [TestFixture]
    public sealed class MedianOfTwoSortedArrays
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData(new[] { 1, 2, 2, 3, 4, 5, 5 }, new[] { 1, 2, 3, 4 })
                .SetName("{a} {m}")
                .Returns(3);
            
            yield return new TestCaseData(new[] { 1, 2, 3, 3, 4, 5, 5 }, new[] { 1, 2, 3, 4 })
                .SetName("{a} {m}")
                .Returns(3);
            
            yield return new TestCaseData(new[] { 1, 2 }, new[] { 3 })
                .SetName("{a} {m}")
                .Returns(2);
            
            yield return new TestCaseData(new[] { 1, 2 }, new[] { 3, 4 })
                .SetName("{a} {m}")
                .Returns(2.5);
            
            yield return new TestCaseData(Array.Empty<int>(), new[] { 1 })
                .SetName("{a} {m}")
                .Returns(1);
            
            
            yield return new TestCaseData(Array.Empty<int>(), new[] { 1, 2 })
                .SetName("{a} {m}")
                .Returns(1.5);
            
            yield return new TestCaseData(Array.Empty<int>(), new[] { 1, 2, 3 })
                .SetName("{a} {m}")
                .Returns(2);
            
            yield return new TestCaseData(new[] { 100001 }, new[] { 100000 })
                .SetName("{a} {m}")
                .Returns(100000.5);
            
            yield return new TestCaseData(new[] { 1 }, new[] { 2, 3, 4 })
                .SetName("{a} {m}")
                .Returns(2.5);
        }

        [TestCaseSource(nameof(TestCases))]
        public double Mine_First(int[] nums1, int[] nums2)
        {
            var totalCount = nums1.Length + nums2.Length;
            var half = totalCount / 2;

            if (nums1.Length > nums2.Length)
            {
                (nums1, nums2) = (nums2, nums1);
            }

            if (nums1.Length == 0)
            {
                if (nums2.Length % 2 == 1)
                {
                    return nums2[half];
                }

                return (nums2[half - 1] + nums2[half]) / 2.0;
            }

            var i = half / 2;
            var j = half - i - 2;
            while (true)
            {
                var left1 = i >= 0 ? nums1[i] : int.MinValue;
                var right1 = i < nums1.Length - 1 ? nums1[i + 1] : int.MaxValue;
                var left2 = j >= 0 ? nums2[j] : int.MinValue;
                var right2 = j < nums2.Length - 1 ? nums2[j + 1] : int.MaxValue;

                if (left1 > right2)
                {
                    i = i - 1;
                    j = half - i - 2;
                    continue;
                }

                if (left2 > right1)
                {
                    i = i + 1;
                    j = half - i - 2;
                    continue;
                }

                if (totalCount % 2 == 1)
                {
                    return Math.Min(right1, right2);
                }

                return (Math.Min(right1, right2) + Math.Max(left1, left2)) / 2.0;
            }
        }
    }
}
