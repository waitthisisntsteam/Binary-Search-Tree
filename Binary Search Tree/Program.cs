using System;

namespace Binary_Search_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            var BST = new BinarySearchTree<int>();

            string answer = "";
            int input = 0;

            while (true)
            {
                Console.WriteLine("Would you like to insert, delete, search, print, or exit?");
                answer = Console.ReadLine();
                if (answer.ToLower() == "insert")
                {
                    Console.WriteLine("What would you like to insert?");
                    input = int.Parse(Console.ReadLine());
                    BST.Insert(input);
                }
                else if (answer.ToLower() == "delete")
                {
                    Console.WriteLine("What would you like to delete?");
                    input = int.Parse(Console.ReadLine());
                    BST.Delete(input);
                }
                else if (answer.ToLower() == "search")
                {
                    Console.WriteLine("What would you like to search for?");
                    input = int.Parse(Console.ReadLine());
                    if (BST.Search(input) != null)
                    {
                        Console.WriteLine($"{BST.Search(input).data} was found.");
                    }
                    else
                    {
                        Console.WriteLine($"{input} was not found.");
                    }
                }
                else if (answer.ToLower() == "print")
                {
                    Console.Clear();
                    BST.PrintTree();
                }
                else if (answer.ToLower() == "exit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Check your spelling.");
                }
            }
        }
    }
}