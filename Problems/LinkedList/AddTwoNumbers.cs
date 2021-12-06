using System.Collections.Generic;
using NUnit.Framework;
using ListNode = Problems.LinkedList.Models.LinkedList;

namespace Problems.LinkedList
{
    [TestFixture]
    public sealed class AddTwoNumbers
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData(new ListNode(3, 4, 2), new ListNode(4, 6, 5))
                .SetName("{a} {m}")
                .Returns(new ListNode(7, 0, 8));

            yield return new TestCaseData(new ListNode(0), new ListNode(0))
                .SetName("{a} {m}")
                .Returns(new ListNode(0));

            yield return new TestCaseData(new ListNode(9, 9, 9, 9, 9, 9, 9), new ListNode(9, 9, 9, 9))
                .SetName("{a} {m}")
                .Returns(new ListNode(8, 9, 9, 9, 0, 0, 0, 1));

            yield return new TestCaseData(new ListNode(0, 1), new ListNode(0, 1, 2))
                .SetName("{a} {m}")
                .Returns(new ListNode(0, 2, 2));

            yield return new TestCaseData(new ListNode(), new ListNode(0, 1))
                .SetName("{a} {m}")
                .Returns(new ListNode(0, 1));

            yield return new TestCaseData(new ListNode(9, 9), new ListNode(1))
                .SetName("{a} {m}")
                .Returns(new ListNode(0, 0, 1));
        }

        [TestCaseSource(nameof(TestCases))]
        public ListNode? Mine_First(ListNode? l1, ListNode? l2)
        {
            var dummy = new ListNode();
            var current = dummy;

            var carry = 0;

            while (l1 != null || l2 != null)
            {
                var value = carry;

                if (l1 != null)
                {
                    value += l1.val;
                }

                if (l2 != null)
                {
                    value += l2.val;
                }

                carry = value / 10;

                current.next = new ListNode(value % 10);
                current = current.next;

                l1 = l1?.next;
                l2 = l2?.next;
            }

            if (carry > 0)
            {
                current.next = new ListNode(carry);
            }

            return dummy.next;
        }
    }
}