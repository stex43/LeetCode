using System.Collections.Generic;
using NUnit.Framework;
using ListNode = Problems.LinkedList.Models.LinkedList;

namespace Problems.LinkedList
{
    [TestFixture]
    public sealed class RemoveNthNodeFromTheEndOfList
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData(new ListNode(1, 2, 3, 4, 5), 2)
                .SetName("{a} {m}")
                .Returns(new ListNode(1, 2, 3, 5));
            
            yield return new TestCaseData(new ListNode(1, 2, 3, 4, 5), 5)
                .SetName("{a} {m}")
                .Returns(new ListNode(2, 3, 4, 5));
            
            yield return new TestCaseData(new ListNode(1), 1)
                .SetName("{a} {m}")
                .Returns(null);
            
            yield return new TestCaseData(new ListNode(1, 2), 1)
                .SetName("{a} {m}")
                .Returns(new ListNode(1));
            
            yield return new TestCaseData(new ListNode(1, 2), 2)
                .SetName("{a} {m}")
                .Returns(new ListNode(2));
        }

        [TestCaseSource(nameof(TestCases))]
        public ListNode? Mine_First(ListNode head, int n)
        {
            var slow = head;
            var fast = head;

            if (fast.next == null)
            {
                return null;
            }

            for (var j = 0; j < n; j++)
            {
                fast = fast!.next;
            }

            if (fast == null)
            {
                return head.next;
            }

            while (fast!.next != null)
            {
                fast = fast.next;
                slow = slow!.next;
            }

            slow!.next = slow!.next!.next;

            return head;
        }
    }
}
