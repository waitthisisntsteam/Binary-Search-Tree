using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Search_Tree
{
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
    }
}