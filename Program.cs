using System;

namespace L6Trees
{

    /*
     * Tasks:
     * 1) Complete the implementation of the Node methods
     * 2) Print out the tree using the different tree traversal metods
     * 3) Test findNode() and deleteNode()
     *
     *
     */
    class Node
    {
        // Attributes
        public Node left;
        public Node right;
        public object item;

        //Methods
        public Node(object data)
        {
            item = data;
            left = null;
            right = null;
        }

        public void addNode(object o, int direction) //1 is left, 2 is right
        {
            if (direction == 1)
            {
                if (left == null) left = new Node(o);
                else left.addNode(o, Compare(o.ToString(), right.item.ToString()));
            }
            else if (direction == 2)
            {
                if (right == null) right = new Node(o);
                else right.addNode(o, Compare(o.ToString(), right.item.ToString()));
            }
        }

        public int Compare(string a, string b)
        {
            char[] compare1 = a.ToCharArray();
            char[] compare2 = b.ToCharArray();
            int count = 0;
            bool found = false;

            while (!found)
            {
                if (count >= compare1.Length)
                {
                    return 1;
                }
                else if (count >= compare2.Length)
                {
                    return 2;
                }

                if ((int)compare1[count] < (int)compare2[count])
                {
                    return 1;
                }
                else if ((int)compare2[count] < (int)compare1[count])
                {
                    return 2;
                }

                count++;
            }

            return -1;
        }
    }

    class BinaryTree
    {
        public Node root;

        public BinaryTree(object o)
        {
            root = new Node(o);
        }

        public void addNode(object o)
        {
            root.addNode(o, root.Compare(o.ToString(), root.item.ToString()));
        }

        public Node findNode(object o)
        {
            Node currentNode = root;
            int direction = 0;

            if (root.item == o) return root;
            try
            {
                while (currentNode.item != o)
                {
                    direction = currentNode.Compare((string)o, (string)currentNode.item);
                    if (direction == 1) currentNode = currentNode.left;
                    else if (direction == 2) currentNode = currentNode.right;
                }
                Console.WriteLine("Item Found");
                return currentNode;
            }
            catch (System.NullReferenceException)
            {
                Console.WriteLine("Item Not Found");
                return null;
            }
        }

        public void deleteNode(object o)
        {
            Node previousNode = root;
            Node currentNode = findNode(o);
            int dir = 0;

            while (previousNode.left != currentNode && previousNode.right  != currentNode )
            {
                dir = previousNode.Compare((string)o, (string)previousNode.item);

                if (dir == 1) previousNode = previousNode.left;
                else if (dir == 2) previousNode = previousNode.right;
            }

            if (currentNode.left != null) previousNode.left = currentNode.left;
            if (currentNode.right != null) previousNode.right = currentNode.right;
            if (currentNode.left == null && currentNode.right == null)
            {
                if (dir == 1) previousNode.left = null;
                else previousNode.right = null;
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

            BinaryTree bob = new BinaryTree("Jan");

            bob.addNode("Feb");
            bob.addNode("Mar");
            bob.deleteNode("Mar");
            bob.findNode("Mar");
        }
    }
}