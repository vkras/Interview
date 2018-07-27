using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    public class TreeLetter
    {
        /// <summary>
        /// Letter, empty/blank for the root element
        /// </summary>
        public char Letter { get; set; }

        public bool IsEnd { get; set; }

        public Dictionary<char, TreeLetter> NextLetters { get; set; }

        public TreeLetter()
        {
            NextLetters = new Dictionary<char, TreeLetter>();
            IsEnd = false;
        }
    }
}
