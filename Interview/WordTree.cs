using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview
{
    public class WordTree
    {
        TreeLetter root;

        public WordTree()
        {
            root = new TreeLetter();
        }

        public TreeLetter Root
        {
            get { return root; }
        }

        public void StoreWord(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return;
            }
            input = input.ToUpper();
            var current = root;
            for (int i = 0; i< input.Length; i++)
            {
                char letter = input[i];
                if (!current.NextLetters.ContainsKey(letter))
                {
                    current.NextLetters[letter] = new TreeLetter()
                    {
                        Letter = letter
                    };
                }
                current = current.NextLetters[letter];
            }
            current.IsEnd = true;
        }

        public List<char> NextLetters(string startsWith)
        {
            var result = new List<char>();
            startsWith = startsWith.ToUpper();
            var current = root;
            for (int i = 0; i < startsWith.Length; i++)
            {
                if (!current.NextLetters.TryGetValue(startsWith[i], out current))
                {
                    return result;
                }
            }
            return current.NextLetters.Select(pair => pair.Key).OrderBy(x => x).ToList();
        }

        public bool IsValidWord(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            var current = root;
            input = input.ToUpper();
            for (int i = 0; i < input.Length; i++)
            {
                if (!current.NextLetters.TryGetValue(input[i], out current))
                {
                    return false;
                }
            }
            return current.IsEnd;
        }
    }
}
