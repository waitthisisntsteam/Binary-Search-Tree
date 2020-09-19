﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Binary_Search_Tree
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    class Node<T>
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