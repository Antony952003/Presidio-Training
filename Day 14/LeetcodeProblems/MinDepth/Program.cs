namespace MinDepth
{
    public class Program
    {
        public async Task<int> MinDepth(Node node)
        {
            if (node == null) return 0;
            if (node.left == null && node.right == null) return 1;
            if (node.left == null) return 1 + await MinDepth(node.right);
            if (node.right == null) return 1 + await MinDepth(node.left);
            int left = 1 + await MinDepth(node.left);
            int right = 1 + await MinDepth(node.right);
            return Math.Min(left, right);
        }

        public async Task<Node> CalculateMinDepth()
        {
            Node head = new Node(1);
            head.left = new Node(2);
            head.right = new Node(7);
            head.left.left = null;
            head.right.left = new Node(3);
            head.right.right = new Node(4);
            head.right.right.right = new Node(5);
            head.left.right = new Node(9);
            return head;
        }


        static async Task Main(string[] args)
        {
            Program program = new Program();
            Node head = await program.CalculateMinDepth();
            int ans = await program.MinDepth(head);
            Console.WriteLine($"The Minimum depth of Tree is {ans}");
        }
    }
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node(int val)
        {
            this.val = val;
            this.left = null;
            this.right = null;
        }
    }
}
