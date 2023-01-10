using System.Collections.Generic;
using NUnit.Framework;

namespace Problems.Arrays
{
    [TestFixture]
    public sealed class MoveZeroes
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData(new[] { 0, 1, 0, 3, 12 })
                .SetName("{a} {m}")
                .Returns(new[] { 1, 3, 12, 0, 0 });

            yield return new TestCaseData(new[] { 0 })
                .SetName("{a} {m}")
                .Returns(new[] { 0 });

            yield return new TestCaseData(new[] { 1, 3, 12 })
                .SetName("{a} {m}")
                .Returns(new[] { 1, 3, 12 });
        }

        [TestCaseSource(nameof(TestCases))]
        public int[] Mine_First(int[] nums)
        {
            var insertPosition = 0;

            foreach (var num in nums)
            {
                if (num != 0)
                {
                    nums[insertPosition] = num;
                    insertPosition++;
                }
            }

            for (var i = insertPosition; i < nums.Length; i++)
            {
                nums[i] = 0;
            }

            return nums;
        }
    }
}
