namespace HasCycle
{
    public class Program
    {
        public bool hasCycle(Node head)
        {
            if(head == null || head.next == null) return false;
            Node slow = head;
            Node fast = slow.next;
            while(fast != slow)
            {
                if(fast == null || fast.next == null) return false;
                slow = slow.next;
                fast = fast.next.next;
            }
            return true;
        }
        public Node calculateHasCycle()
        {
            Node head = new Node(1);
            head.next = new Node(2);
            head.next.next = new Node(3);
            head.next.next.next = new Node(4);
            head.next.next.next.next = head.next.next;
            return head;
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Node head = program.calculateHasCycle();
            bool ans = program.hasCycle(head);
        }
    }
    public class Node
    {
        public int data;
        public Node next;
        public Node(int data)
        {
            this.data = data;
            this.next = null;
        }
    }
}
