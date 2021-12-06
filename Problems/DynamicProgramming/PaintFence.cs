using System.Collections.Generic;
using NUnit.Framework;

namespace Problems.DynamicProgramming
{
    [TestFixture]
    public sealed class PaintFence
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData(3, 2)
                .SetName("{a} {m}")
                .Returns(6);

            yield return new TestCaseData(1, 1)
                .SetName("{a} {m}")
                .Returns(1);

            yield return new TestCaseData(7, 2)
                .SetName("{a} {m}")
                .Returns(42);

            yield return new TestCaseData(13, 5)
                .SetName("{a} {m}")
                .Returns(827207680);
        }


        #region Mine_First

        [TestCaseSource(nameof(TestCases))]
        public int Mine_First(int n, int k)
        {
            return Count(n, k, -1, -1, 0);
        }

        private int Count(int n, int k, int prev, int prevPrev, int position)
        {
            if (position == n)
            {
                return 0;
            }

            if (position == n - 1)
            {
                return prev == prevPrev && prev != -1 ? k - 1 : k;
            }

            var variants = 0;
            for (var i = 0; i < k; i++)
            {
                if (prev == prevPrev && prev == i)
                {
                    continue;
                }

                variants += Count(n, k, i, prev, position + 1);
            }

            return variants;
        }

        #endregion


        #region Leetcode_TopDown

        [TestCaseSource(nameof(TestCases))]
        public int Leetcode_TopDown(int n, int k)
        {
            return Count(n, k, new Dictionary<int, int>());
        }

        private int Count(int n, int k, Dictionary<int, int> memo)
        {
            if (n == 1)
            {
                return k;
            }

            if (n == 2)
            {
                return k * k;
            }

            if (memo.ContainsKey(n))
            {
                return memo[n];
            }

            var res = (k - 1) * (Count(n - 1, k, memo) + Count(n - 2, k, memo));
            memo[n] = res;

            return res;
        }

        #endregion

        [TestCaseSource(nameof(TestCases))]
        public int Leetcode_BottomUpWithArray(int n, int k)
        {
            var array = new int[n + 2];

            array[1] = k;
            array[2] = k * k;

            for (var i = 3; i <= n; i++)
            {
                array[i] = (k - 1) * (array[i - 1] + array[i - 2]);
            }

            return array[n];
        }

        [TestCaseSource(nameof(TestCases))]
        public int Leetcode_BottomUp(int n, int k)
        {
            if (n == 1)
            {
                return k;
            }

            if (n == 2)
            {
                return k * k;
            }

            var prevPrevPost = k;
            var prevPost = k * k;
            var currentPost = 0;

            for (var i = 3; i <= n; i++)
            {
                currentPost = (k - 1) * (prevPrevPost + prevPost);

                prevPrevPost = prevPost;
                prevPost = currentPost;
            }

            return currentPost;
        }
    }
}
