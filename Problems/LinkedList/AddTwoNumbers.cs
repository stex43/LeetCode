using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Problems.LinkedList
{
    [TestFixture]
    [NonParallelizable]
    public sealed class AddTwoNumbers
    {
        private static readonly ListNode q1 = new ListNode(3, new ListNode(4, new ListNode(2)));
        private static readonly ListNode q2 = new ListNode(3, new ListNode(4, new ListNode(2)));

        private static readonly List<ListNode> q = new List<ListNode> {q1, q2};

        private static string FileName = nameof(AddTwoNumbers);
        private static IEnumerable<ListNode> testCases;

        private static StreamReader reader;

        public AddTwoNumbers()
        {
            var namespaceName = typeof(AddTwoNumbers).Namespace;
            var t = MethodBase.GetCurrentMethod().DeclaringType;
            reader = new StreamReader($"{namespaceName.Split(".")[1]}\\TestData\\{FileName}.txt");
            testCases = Read();
        }

        private static IEnumerable<ListNode> Read()
        {
            var line = reader.ReadLine();
            var split = line.Split().Select(int.Parse).ToArray();
            var listNode = new ListNode(split[0]);
            var iterator = listNode;
            for (var i = 1; i < split.Length; i++)
            {
                var newNode = new ListNode(split[i]);
                iterator.next = newNode;
                iterator = newNode;
            }

            yield return listNode;
        }

        [Test]
        [TestCaseSource(nameof(testCases))]
        public void Test(ListNode listNode)
        {
            var actualResult = AddTwoNumbers1();
        }

        public ListNode AddTwoNumbers1()
        {
            var l11 = new ListNode(3);
            var l12 = new ListNode(4, l11);
            var l13 = new ListNode(2, l12);

            var l21 = new ListNode(4);
            var l22 = new ListNode(6, l21);
            var l23 = new ListNode(5, l22);

            var l1 = l13;
            var l2 = l23;

            ListNode l = null;
            ListNode iterator = null;
            var add = 0;
            while (l1 != null && l2 != null)
            {
                var value = l1.val + l2.val + add;
                add = value / 10;
                value %= 10;

                var node = new ListNode(value);

                if (l == null)
                {
                    l = node;
                    iterator = node;
                }
                else
                {
                    iterator.next = node;
                    iterator = node;
                }

                l1 = l1.next;
                l2 = l2.next;
            }

            if (l1 == null)
            {
                l1 = l2;
            }

            while (l1 != null)
            {
                var value = l1.val + add;
                add = value / 10;
                value %= 10;

                var node = new ListNode(value);

                iterator.next = node;
                iterator = node;

                l1 = l1.next;
            }

            if (add > 0)
            {
                var node = new ListNode(add);
                iterator.next = node;
            }

            return l;
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
        }
    }
}