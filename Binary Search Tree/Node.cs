using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Transactions;

namespace Binary_Search_Tree
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    public class Node<T>
    {
        public Node<T> parent;
        public Node<T> left;
        public Node<T> right;
        public T data;

        public Node(T data)
        {
            this.data = data;
        }

        public int ChildCount
        {
            get
            {
                int count = 0;
                if (left != null)
                {
                    count++;
                }
                if (right != null)
                {
                    count++;
                }
                return count;
            }
        }

        private string GetDebuggerDisplay()
        {
            string par = "null";
            string l = "null";
            string r = "null";

            if (parent != null)
            {
                par = parent.data.ToString();
            }

            if (left != null)
            {
                l = left.data.ToString();
            }

            if (right != null)
            {
                r = right.data.ToString();
            }

            return $"Val: {data}, Par: {par}, L: {l}, R: {r}";
        }
    }
}