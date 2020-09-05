using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Search_Tree
{
    class BinarySearchTree<T> where T : IComparable<T>
    {
        public Node<T> root;
        int Count = 0;

        public void Insert(T data)
        {
            if (Count == 0)
            {
                Node<T> temp = new Node<T>(data);               
                root = temp;
                Count++;
                return;
            }
            else
            {
                Node<T> temp = new Node<T>(data);
                Node<T> current = root;
                while (true)
                {
                    if (temp.data.CompareTo(current.data) == 1)
                    {
                        if (current.right == null)
                        {
                            current.right = temp;
                            return;
                        }
                        else
                        {
                            current = current.right;
                        }
                    }
                    else if (temp.data.CompareTo(current.data) == -1)
                    {
                        if (current.left == null)
                        {
                            current.left = temp;
                            break;
                        }
                        else
                        {
                            current = current.left;
                        }
                    }
                    else
                    {
                        throw new Exception("Can not enter a duplicate.");
                    }
                }
            }
        }

        public void Search(T data)
        {
            Node<T> current = root;
            while(true)
            {
                if (current.data.CompareTo(data) == 0)
                {
                    Console.WriteLine($"{data} is in the tree.");
                    return;
                }
                else
                {
                    if (current.data.CompareTo(data) == 1)
                    {
                        current = current.left;
                    }
                    else
                    {
                        current = current.right;
                    }
                }
            }
        }
    }
}