using System.Collections.Generic;
using NUnit.Framework;
using ListNode = Problems.LinkedList.Models.LinkedList;

namespace Problems.LinkedList
{
    public sealed class ReverseLinkedList
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData(new ListNode(1, 2, 3, 4, 5))
                .SetName("{a}")
                .Returns(new ListNode(5, 4, 3, 2, 1));

            yield return new TestCaseData(new ListNode(1, 2))
                .SetName("{a}")
                .Returns(new ListNode(2, 1));

            yield return new TestCaseData(new ListNode(1))
                .SetName("{a}")
                .Returns(new ListNode(1));

            yield return new TestCaseData(null)
                .SetName("{a}")
                .Returns(null);
        }

        [TestCaseSource(nameof(TestCases))]
        public ListNode Mine_Iterative(ListNode head)
        {
            var stack = new Stack<ListNode>();
            var current = head;

            while (current != null)
            {
                stack.Push(current);
                current = current.next;
            }

            var dummyHead = new ListNode();
            current = dummyHead;

            while (stack.Count != 0)
            {
                var node = stack.Pop();
                node.next = null;

                current.next = node;
                current = node;
            }
            
            return dummyHead.next;
        }

        [TestCaseSource(nameof(TestCases))]
        public ListNode Leetcode_Iterative(ListNode head)
        {
            ListNode? previous = null;
            var current = head;

            while (current != null)
            {
                var next = current.next;

                current.next = previous;
                previous = current;

                current = next;
            }

            return previous;
        }

        [TestCaseSource(nameof(TestCases))]
        public ListNode Leetcode_Recursive(ListNode head)
        {
            return ReverseList(head);
        }

        private ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            var reversed = ReverseList(head.next);
            head.next.next = head;
            head.next = null;

            return reversed;
        }
    }
}
