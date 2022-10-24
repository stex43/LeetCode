using System;
using System.Collections.Generic;

namespace Problems.LinkedList.Models
{

    public class LinkedList
    {
        public int val;

        public LinkedList? next;

        public LinkedList(int val = 0, LinkedList? next = null)
        {
            this.val = val;
            this.next = next;
        }

        // for test use only
        internal LinkedList(params int[] values)
        {
            var dummyHead = new LinkedList();
            var current = dummyHead;

            foreach (var value in values)
            {
                current.next = new LinkedList(value);
                current = current.next;
            }

            this.next = dummyHead.next.next;
            this.val = dummyHead.next.val;
        }

        public override string ToString()
        {
            var values = new List<int>();
            var current = this;
            while (current != null)
            {
                values.Add(current.val);
                current = current.next;
            }

            return string.Join(' ', values);
        }

        protected bool Equals(LinkedList other)
        {
            return val == other.val && Equals(next, other.next);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((LinkedList)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(val, next);
        }
    }
}
