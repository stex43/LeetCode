using System.Collections.Generic;
using NUnit.Framework;
using ListNode = Problems.LinkedList.Models.LinkedList;

namespace Problems.LinkedList
{
    [TestFixture]
    public sealed class RemoveDuplicatesFromSortedList
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData(new ListNode(1, 1, 2))
                .SetName("{a}")
                .Returns(new ListNode(1, 2));

            yield return new TestCaseData(new ListNode(1, 1, 2, 3, 3))
                .SetName("{a}")
                .Returns(new ListNode(1, 2, 3));

            yield return new TestCaseData(new ListNode(1, 1, 1))
                .SetName("{a}")
                .Returns(new ListNode(1));

            yield return new TestCaseData(new ListNode(1, 2, 3))
                .SetName("{a}")
                .Returns(new ListNode(1, 2, 3));

            yield return new TestCaseData(null)
                .SetName("{a}")
                .Returns(null);
        }

        [TestCaseSource(nameof(TestCases))]
        public ListNode Mine_First(ListNode head)
        {
            var current = head;

            while (current?.next != null)
            {
                var next = current.next;

                if (current.val != next.val)
                {
                    current = next;
                    continue;
                }
                
                current.next = next.next;
            }

            return head;
        }
    }
}
