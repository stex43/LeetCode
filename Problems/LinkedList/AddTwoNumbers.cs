﻿using System.Collections.Generic;
using System.IO;
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
        
        private static readonly StreamReader Reader;
        private static IEnumerable<TestCase> TestCases;
        
        static AddTwoNumbers()
        {
            var namespaceName = typeof(AddTwoNumbers).Namespace;
            Reader = new StreamReader($"{namespaceName.Split(".")[1]}\\TestData\\{nameof(AddTwoNumbers)}.txt");
            TestCases = 
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Reader.Dispose();
        }

        private static IEnumerable<TestCase> ReadTestCases()
        {
            while (!Reader.EndOfStream)
            {
                
            }
        }

        private static TestCase ReadTestCase()
        {
            var line = Reader.ReadLine();

        }

        private static ListNode ParseListNode(string fileLine)
        {
            var split = fileLine.Split();

        }

        [Test]
        public void Test()
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
            ListNode iterrator = null;
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
                    iterrator = node;
                }
                else
                {
                    iterrator.next = node;
                    iterrator = node;
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

                iterrator.next = node;
                iterrator = node;

                l1 = l1.next;
            }

            if (add > 0)
            {
                var node = new ListNode(add);
                iterrator.next = node;
            }

            return l;
        }

        public class ListNode
        {
            public int val;

            public ListNode next;

            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        private class TestCase
        {
            public readonly ListNode First;

            public readonly ListNode Second;

            public readonly ListNode ExpectedResult;

            public TestCase(ListNode first, ListNode second, ListNode expectedResult)
            {
                this.First = first;
                this.Second = second;
                this.ExpectedResult = expectedResult;
            }
        }
    }
}