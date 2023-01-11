using System.Collections.Generic;
using NUnit.Framework;
using ListNode = Problems.LinkedList.Models.LinkedList;

namespace Problems.LinkedList
{
    [TestFixture]
    public sealed class MiddleOfTheLinkedList
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData(new ListNode(1, 2, 3, 4, 5))
                .SetName("{a} {m}")
                .Returns(new ListNode(3, 4, 5));
            
            yield return new TestCaseData(new ListNode(1,2,3,4,5,6))
                .SetName("{a} {m}")
                .Returns(new ListNode(4, 5, 6));
        }

        [TestCaseSource(nameof(TestCases))]
        public ListNode Mine_First(ListNode head)
        {
            var slow = head;
            var fast = head;

            while (fast.next != null)
            {
                fast = fast.next;
                if (fast.next == null)
                {
                    slow = slow!.next;
                    break;
                }

                fast = fast.next;

                slow = slow!.next;
            }

            return slow!;
        }
    }
}
