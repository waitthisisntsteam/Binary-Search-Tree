using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Binary_Search_Tree
{
    [DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
    class BinarySearchTree<T> where T : IComparable<T>
    {
        public Node<T> root;
        int Count = 0;

        public void PrintTree()
        {
            PrintTreeRecursive(root, Console.WindowWidth / 2, 0, 18);
        }

        private void PrintTreeRecursive(Node<T> node, int x, int y, int dx)
        {
            if (node == null)
            {
                return;
            }

            Console.SetCursorPosition(x, y);
            Console.WriteLine(node.data);
            PrintTreeRecursive(node.left, x - dx, y + 1, dx - 6);
            PrintTreeRecursive(node.right, x + dx, y + 1, dx - 6);

        }

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
                            current.right.parent = current;
                            Count++;
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
                            current.left.parent = current;
                            Count++;
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
                    return current;
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

        public bool IsRightChild(Node<T> node)
        {
            if (node.parent == null)
            {
                return false;
            }

            return (node.parent.right == node);
           
        }

        public bool IsRightChild(T data)
        {
            var current = Search(data);
            if (current.parent == null)
            {
                return false;
            }
            if (current.parent.right == current)
            {
                return true;
            }
            return false;
        }

        public bool IsLeftChild(T data)
        {
            var current = Search(data);
            if (current.parent == null)
            {
                return false;
            }
            if (current.parent.left == current)
            {
                return true;
            }
            return false;
        }

        public bool Delete(T data)
        {
            var current = Search(data);
            if (Count == 0)
            {
                return false;
            }
            else if (current == null)
            {
                return false;
            }
            //if current has 2 children
            if (current.ChildCount == 2)
            {
                Count--;
                var candidateNode = GetMinimum(current.right);
                current.data = candidateNode.data;
                current = candidateNode;
                return true;
            }
            //if current has no children
            if (current.ChildCount == 0)
            {
                Count--;
                if (current == root)
                {
                    root = null;
                    Count = 0;
                    return true;
                }
                if (IsRightChild(current))
                {
                    current.parent.right = null;
                    return true;
                }
                current.parent.left = null;
                return true;
            }
            //if current has one child
            else if (current.ChildCount == 1)
            {
                Node<T> child = current.left;

                if (child == null)
                {
                    child = current.right;
                }
                if (current == root)
                {
                    root = child;
                }
                else if (IsRightChild(current))
                {
                    current.parent.right = child;
                }
                else
                {
                    current.parent.left = current.left;
                }

                child.parent = current.parent;
                Count--;
                return true;
            }

            return false;
                      
        }

        private Node<T> GetMinimum(Node<T> node)
        {
            while (node.left != null)
            {
                node = node.left;
            }

            return node;
        }

        private string GetDebuggerDisplay()
        {
            return $"Root: {root?.data.ToString() ?? "null"}, Count: {Count}";
        }
    }
}