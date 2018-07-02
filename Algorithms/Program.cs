using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{


    class Program
    {
        int position = 0;
        

        static void Main(string[] args)
        {
            #region Binary Search
            //Let us create following BST
            //            50
            //         /      \
            //        30      70
            //      /  \     /  \
            //     20   40  60   80

            MyBinaryTree bTree = new MyBinaryTree();
            Node node = null;
            node = bTree.AddData(ref node, 50);
            node = bTree.AddData(ref node, 30);
            node = bTree.AddData(ref node, 70);
            node = bTree.AddData(ref node, 20);
            node = bTree.AddData(ref node, 40);
            node = bTree.AddData(ref node, 60);
            node = bTree.AddData(ref node, 80);

            int height = bTree.CalulcateHeight(node);
            Node node1 = bTree.Search(node, 20);


            MyBinaryTree bTree2 = new MyBinaryTree();
            Node node2 = null;
            bTree2.AddData(ref node2, 1);
            bTree2.AddData(ref node2, 2);
            bTree2.AddData(ref node2, 3);
            bTree2.AddData(ref node2, 4);
            bTree2.AddData(ref node2, 5);
            bTree2.AddData(ref node2, 6);
            bTree2.AddData(ref node2, 7);

            height = bTree.CalulcateHeight(node2);
            node1 = bTree.Search(node2, 5);

            #endregion

            #region BinarySearch on Array
            int[] values = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                values[i] = i;
            }

            //Array.BinarySearch(values, 665);
            int g = BinarySearch.MyBSearch(values, 0, 999, 665);
            #endregion


            #region MyRegion
            int[] arr = new int[10] { 100, 50, 20, 40, 10, 60, 80, 70, 90, 30 };

            //SortingAlgorithms.SelectionSort(ref arr);
            SortingAlgorithms.InsertionSort(ref arr);

            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine(arr[i]);
            #endregion

        }
    }
}
