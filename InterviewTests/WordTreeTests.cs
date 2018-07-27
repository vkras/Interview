using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Interview;

namespace InteviewTests
{
    [TestClass]
    public class WordTreeTests
    {
        [TestMethod]
        public void WordTree_Store()
        {
            var tree = new WordTree();
            tree.StoreWord("Apple");
            tree.StoreWord("application");
            var next = tree.NextLetters("a");
            Assert.AreEqual(next.Count, 1);
            Assert.AreEqual(next[0], 'P');
        }

        [TestMethod]
        public void WordTree_Next_Appl()
        {
            var tree = new WordTree();
            tree.StoreWord("Apple");
            tree.StoreWord("application");
            var next = tree.NextLetters("appl");
            Assert.AreEqual(next.Count, 2);
            Assert.AreEqual(next[0], 'E');
            Assert.AreEqual(next[1], 'I');
        }

        [TestMethod]
        public void WordTree_Next_Empty()
        {
            var tree = new WordTree();
            tree.StoreWord("Apple");
            tree.StoreWord("application");
            var next = tree.NextLetters("");
            Assert.AreEqual(next.Count, 1);
            Assert.AreEqual(next[0], 'A');
        }

        [TestMethod]
        public void WordTree_CheckWord_Valid()
        {
            var tree = new WordTree();
            tree.StoreWord("Apple");
            tree.StoreWord("Apples");
            tree.StoreWord("application");
            bool result = tree.IsValidWord("apple");
            bool result2 = tree.IsValidWord("apples");
            Assert.AreEqual(result, true);
            Assert.AreEqual(result2, true);
        }

        [TestMethod]
        public void WordTree_CheckWord_Invalid()
        {
            var tree = new WordTree();
            tree.StoreWord("Apple");
            tree.StoreWord("Apples");
            tree.StoreWord("application");
            bool result = tree.IsValidWord("applesss");
            bool result2 = tree.IsValidWord("pple");
            Assert.AreEqual(result, false);
            Assert.AreEqual(result2, false);
        }
    }
}
