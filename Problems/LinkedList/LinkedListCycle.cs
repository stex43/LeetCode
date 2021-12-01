using System;
using System.Collections.Generic;
using NUnit.Framework;

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

        public class ListNode
        {
            public int val;

            public ListNode? next;

            public ListNode(int val = 0, ListNode? next = null)
            {
                this.val = val;
                this.next = next;
            }

            // for test use only
            public ListNode(int pos, params int[] values)
            {
                var dummyHead = new ListNode();
                var current = dummyHead;

                ListNode? cycled = null;

                for (var i = 0; i < values.Length; i++)
                {
                    current.next = new ListNode(values[i]);
                    current = current.next;

                    if (pos == i)
                    {
                        cycled = current;
                    }
                }

                current.next = cycled;

                this.next = dummyHead.next.next;
                this.val = dummyHead.next.val;
            }
        }
    }
}
