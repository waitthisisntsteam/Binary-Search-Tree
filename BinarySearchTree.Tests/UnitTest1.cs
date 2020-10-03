using System;
using Xunit;
using Binary_Search_Tree;

namespace BinarySearchTree.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void IsTreeEmpty()
        {
            var BST = new BinarySearchTree<int>();
            Assert.Equal(0, BST.Count);
            Assert.Empty(BST);
        }
    }
}
