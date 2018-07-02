using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
Let us create following BST
            50
         /      \
        30	    70
      /  \     /  \
     20   40  60   80 
*/

namespace Algorithms
{
    public class Node
    {
        public int value;
        public Node Left;
        public Node Right;
        public Node(int val) { value = val;  Left = null; Right = null; }
    }

    public class MyBinaryTree
    {
        private int height = 0;
        Node GetNewNode(int value)
        {
            Node tr = new Node(value);
            return tr;
        }

        public Node AddData(ref Node node, int value)
        {
            if (node == null)
            {
                node = GetNewNode(value);
            }
            else if (value < node.value)
            {
                node.Right = AddData(ref node.Right, value);
            }
            else 
            {
                node.Left = AddData(ref node.Left, value);
            }

            return node;
        }
        public int CalulcateHeight(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            if (node.Left != null)
            {
                height += 1;
                height = CalulcateHeight(node.Left);
            }
            else if (node.Right != null)
            {
                height += 1;
                height = CalulcateHeight(node.Right);
            }

            return height;
        }

        public Node Search(Node node, int value)
        {
            if (node == null)
            {
                return null;
            }
            else if (node.value == value)
            {
                return node;
            }
            else if (value < node.value)
            {
                return Search(node.Right, value);
            }
            else
            {
                return Search(node.Left, value);
            }

            return null;
        }
    }
}