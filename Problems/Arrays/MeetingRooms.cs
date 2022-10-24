using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Problems.Arrays
{
    [TestFixture]
    public sealed class MeetingRooms
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData(new[] { 0, 30, 5, 10, 15, 20 })
                .SetName("{a} {m}")
                .Returns(false);

            yield return new TestCaseData(new[] { 7, 10, 2, 4 })
                .SetName("{a} {m}")
                .Returns(true);
        }

        [TestCaseSource(nameof(TestCases))]
        public bool Mine_First(int[] values)
        {
            var intervals = GetIntervals(values);

            System.Array.Sort(intervals, (x, y) => x[0].CompareTo(y[0]));

            for (var i = 1; i < intervals.Length; i++)
            {
                var currentInterval = intervals[i];
                var prevInterval = intervals[i - 1];

                if (currentInterval[0] < prevInterval[1])
                {
                    return false;
                }
            }

            return true;
        }

        [TestCaseSource(nameof(TestCases))]
        public bool Leetcode_BruteForce(int[] values)
        {
            var intervals = GetIntervals(values);

            for (var i = 0; i < intervals.Length; i++)
            {
                for (var j = i + 1; j < intervals.Length; j++)
                {
                    if (Math.Min(intervals[i][1], intervals[j][1]) > Math.Max(intervals[i][0], intervals[j][0]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static int[][] GetIntervals(int[] values)
        {
            if (values.Length % 2 == 1)
            {
                throw new ArgumentException($"array {{{string.Join(' ', values)}}} has wrong length={values.Length}");
            }

            var list = new List<int[]>(values.Length / 2);
            for (var i = 0; i < values.Length; i += 2)
            {
                list.Add(new[] { values[i], values[i + 1] });
            }

            return list.ToArray();
        }
    }
}
