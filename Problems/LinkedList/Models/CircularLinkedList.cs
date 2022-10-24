namespace Problems.LinkedList.Models
{
    public sealed class CircularLinkedList
    {
        public int val;

        public CircularLinkedList? next;

        public CircularLinkedList(int val = 0, CircularLinkedList? next = null)
        {
            this.val = val;
            this.next = next;
        }

        // for test use only
        internal CircularLinkedList(int pos, params int[] values)
        {
            var dummyHead = new CircularLinkedList();
            var current = dummyHead;

            CircularLinkedList? cycled = null;

            for (var i = 0; i < values.Length; i++)
            {
                current.next = new CircularLinkedList(values[i]);
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
