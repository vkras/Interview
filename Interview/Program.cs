using System;
using System.Linq;

namespace Interview
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Select mode (1 - brackets validation, 2 - word tree lookup, 3 - exit): ");
                var key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case '1':
                        DoBrackets();
                        break;
                    case '2':
                        DoWordLookup();
                        break;
                    case '3':
                        return;
                }
            }
        }

        private static void DoBrackets()
        {
            Console.WriteLine("Enter expression with {},[],() brackers; enter empty string to return to main menu");
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }
                bool result = BracketValidator.Validate(input);
                Console.WriteLine("Expression is {0}", result ? "valid" : "invalid");
            }
        }

        private static void DoWordLookup()
        {
            var wordTree = new WordTree();
            Console.WriteLine("Step 1: populate word lookup. End each word with new line, empty line finishes step 1");
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }
                wordTree.StoreWord(input);
            }
            while (true)
            {
                Console.WriteLine("Select mode (1 - propose next letter, 2 - validate word, 3 - return to main menu): ");
                var key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case '1':
                        NextLetter(wordTree);
                        break;
                    case '2':
                        ValidateWord(wordTree);
                        break;
                    case '3':
                        return;
                }
            }
        }

        private static void NextLetter(WordTree tree)
        {
            Console.WriteLine("Enter one of the available letters below, new line returns to main menu");
            var current = tree.Root;
            string currentString = string.Empty;
            while (true)
            {
                var options = string.Join(",", current.NextLetters.Select(x => x.Key));
                if (string.IsNullOrEmpty(options))
                {
                    Console.WriteLine("No more options available");
                    break;
                }
                Console.WriteLine("{0} [{1}]", currentString, options);
                var key = Char.ToUpper(Console.ReadKey(true).KeyChar);
                if (key == 13)
                {
                    break;
                }
                if (current.NextLetters.ContainsKey(key))
                {
                    currentString += key;
                    current = current.NextLetters[key];
                }
            }
        }

        private static void ValidateWord(WordTree tree)
        {
            Console.WriteLine("Enter word to validate, empty line returns to main menu");
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }
                bool result = tree.IsValidWord(input);
                Console.WriteLine("Word '{0}' is {1}found in dictionary", input, result ? string.Empty : "not ");
            }
        }
    }
}