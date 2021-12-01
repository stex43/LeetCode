using System.Collections.Generic;
using NUnit.Framework;
using ListNode = Problems.LinkedList.Models.CircularLinkedList;

namespace Problems.LinkedList
{
    [TestFixture]
    public sealed class LinkedListCycle
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData(new ListNode(1, 3, 2, 0, -4))
                .SetName("3 2 0 -4, pos=1")
                .Returns(true);

            yield return new TestCaseData(new ListNode(0, 1, 2))
                .SetName("1 2, pos=0")
                .Returns(true);

            yield return new TestCaseData(new ListNode(1))
                .SetName("1, pos=-1")
                .Returns(false);
        }

        [TestCaseSource(nameof(TestCases))]
        public bool Mine_First(ListNode head)
        {
            var hashSet = new HashSet<ListNode>();

            var current = head;
            while (current != null)
            {
                if (hashSet.Contains(current))
                {
                    return true;
                }

                hashSet.Add(current);

                current = current.next;
            }

            return false;
        }

        [TestCaseSource(nameof(TestCases))]
        public bool Leetcode_TwoPointers(ListNode head)
        {
            var slow = head;
            var fast = head.next;
            while (fast?.next?.next != null)
            {
                if (fast == slow)
                {
                    return true;
                }

                slow = slow.next;
                fast = fast.next.next;
            }

            return false;
        }
    }
}
