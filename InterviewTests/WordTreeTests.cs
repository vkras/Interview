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
        private WordTree _tree;

        [TestInitialize]
        public void SetUp()
        {
            _tree = new WordTree();
            _tree.StoreWord("Apple");
            _tree.StoreWord("Apples");
            _tree.StoreWord("application");
        }

        [TestMethod]
        public void WordTree_Store()
        {
            var next = _tree.NextLetters("a");
            Assert.AreEqual(next.Count, 1);
            Assert.AreEqual(next[0], 'P');
        }

        [TestMethod]
        public void WordTree_Next_Appl()
        {
            var next = _tree.NextLetters("appl");
            Assert.AreEqual(next.Count, 2);
            Assert.AreEqual(next[0], 'E');
            Assert.AreEqual(next[1], 'I');
        }

        [TestMethod]
        public void WordTree_Next_Empty()
        {
            var next = _tree.NextLetters("");
            Assert.AreEqual(next.Count, 1);
            Assert.AreEqual(next[0], 'A');
        }

        [TestMethod]
        public void WordTree_CheckWord_Valid()
        {
            bool result = _tree.IsValidWord("apple");
            bool result2 = _tree.IsValidWord("apples");
            Assert.AreEqual(result, true);
            Assert.AreEqual(result2, true);
        }

        [TestMethod]
        public void WordTree_CheckWord_Invalid()
        {
            bool result = _tree.IsValidWord("applesss");
            bool result2 = _tree.IsValidWord("pple");
            Assert.AreEqual(result, false);
            Assert.AreEqual(result2, false);
        }
    }
}
