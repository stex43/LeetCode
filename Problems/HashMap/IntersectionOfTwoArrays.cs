using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Problems.HashMap
{
    [TestFixture]
    public sealed class IntersectionOfTwoArrays
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData(new[] { 1, 2, 2, 1 }, new[] { 2, 2 })
                .SetName("{a}")
                .Returns(new[] { 2 });

            yield return new TestCaseData(new[] { 4, 9, 5 }, new[] { 9, 4, 9, 8, 4 })
                .SetName("{a}")
                .Returns(new TestUnorderedCollection<int> { 9, 4 });
        }

        [TestCaseSource(nameof(TestCases))]
        public int[] Mine_First(int[] nums1, int[] nums2)
        {
            return nums1.Intersect(nums2).ToArray();
        }
    }
}
