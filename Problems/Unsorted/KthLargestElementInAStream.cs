using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Problems.Unsorted
{
    [TestFixture]
    public sealed class KthLargestElementInAStream
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData(3, new[] { 4, 5, 8, 2}, new[] { 3, 5, 10, 9, 4 })
                .SetName("{a} {m}")
                .Returns(new List<int?> { null, 4, 5, 5, 8, 8 });

            yield return new TestCaseData(1, Array.Empty<int>(), new[] { -3, -2, -4, 0, 4 })
                .SetName("{a} {m}")
                .Returns(new List<int?> { null, -3, -2, -2, 0, 4 });

            yield return new TestCaseData(2, new[] { 0 }, new[] { -1, 1, -2, -4, 3 })
                .SetName("{a} {m}")
                .Returns(new List<int?> { null, -1, 0, 0, 0, 1 });
        }

        public abstract class KthLargest
        {
            public abstract int Add(int val);
        }
        
        private static List<int?> GetResults(KthLargest kth, int[] adds)
        {
            var results = new List<int?>(adds.Length + 1) { null };

            foreach (var add in adds)
            {
                var result = kth.Add(add);
                results.Add(result);
            }

            return results;
        }

        #region Mine_First

        public class KthLargest_Mine_First : KthLargest
        {
            private readonly LinkedList<int> list;
            private readonly int K;

            public KthLargest_Mine_First(int k, int[] nums)
            {
                Array.Sort(nums);

                this.list = new LinkedList<int>(nums.Skip(nums.Length - k));
                this.K = k;
            }

            public override int Add(int val)
            {
                var listNode = this.list.First;

                if (listNode == null || listNode.Value >= val)
                {
                    this.list.AddFirst(val);
                }
                else
                {
                    while (listNode!.Next != null && listNode!.Next!.Value < val)
                    {
                        listNode = listNode.Next;
                    }

                    this.list.AddAfter(listNode, val);
                }

                if (this.K < this.list.Count)
                {
                    this.list.RemoveFirst();
                }

                return this.list.First!.Value;
            }
        }

        [TestCaseSource(nameof(TestCases))]
        public List<int?> Mine_First(int k, int[] init, int[] adds)
        {
            var kth = new KthLargest_Mine_First(k, init);

            return GetResults(kth, adds);
        }

        #endregion
    }
}
