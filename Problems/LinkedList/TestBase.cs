using System.Collections.Generic;
using System.IO;
using System.Reflection;
using NUnit.Framework;

namespace Problems.LinkedList
{
    public abstract class TestBase
    {
        protected static IEnumerable<AddTwoNumbers.ListNode> testCases;

        private static StreamReader reader;

        static TestBase()
        {
            var t = MethodBase.GetCurrentMethod().DeclaringType;
            var namespaceName = t.Namespace;
            reader = GetReader()
            testCases = ReadTestCases();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            reader.Dispose();
        }

        protected abstract StreamReader GetReader();

        protected static IEnumerable<AddTwoNumbers.ListNode> ReadTestCases()
        {
            while (!reader.EndOfStream)
            {
                
            }
        }
    }
}
