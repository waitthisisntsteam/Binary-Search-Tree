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
                var temp = new Node<T>(data);               
                root = temp;
                Count++;
                return;
            }
            else
            {
                var temp = new Node<T>(data);
                var current = root;
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

        public Node<T> Search(T data)
        {
            var current = root;
            while (current != null)
            {
                int comp = data.CompareTo(current.data);

                if (comp == 0)
                {
                    break;
                }
                else if (comp < 0)
                {
                    current = current.left;
                }
                else
                {
                    current = current.right;
                }
            }
            return null;
        }

        public bool IsRightChild(T data)
        {
            var current = Search(data);
            if (current.parent.right == current)
            {
                return true;
            }
            return false;
        }

        public bool IsLeftChild(T data)
        {
            var current = Search(data);
            if (current.parent.left == current)
            {
                return true;
            }
            return false;
        }

        public void Delete(T data)
        {
            var current = Search(data);
            //errors
            if (Count == 0)
            {
                throw new Exception("The tree is empty.");
            }
            else if (current == null)
            {
                throw new Exception("The tree does not contain the given input.");
            }
            //if current is root
            else if (current == root)
            {
                root = null;
            }
            //if current has no children
            else if (current.left == null && current.right == null)
            {
                if (IsRightChild(current.data))
                {
                    current.parent.right = null;
                }
                else
                {
                    current.parent.left = null;
                }
            }
            //if current has one child
            else if (current.left == null && current.right != null)
            {
                if (IsRightChild(current.data))
                {
                    current.parent.right = current.right;
                    current.parent.right.right = null;
                }
                else
                {
                    current.parent.left = current.right;
                    current.parent.left.right = null;
                }
            }
            else if (current.left != null && current.right == null)
            {
                if (IsLeftChild(current.data))
                {
                    current.parent.left = current.left;
                    current.parent.left.left = null;
                }
                else
                {
                    current.parent.right = current.left;
                    current.parent.right.left = null;
                }
            }
            //if current has 2 children
            else
            {
                var temp = current.left;
                while (temp.right != null)
                {
                    temp = temp.right;
                }
                current.parent.left = temp;
                current.parent.left.right = null;
            }
        }
    }
}