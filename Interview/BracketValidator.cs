using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    public static class BracketValidator
    {
        const char ROUND_BRACKET_OPEN = '(';
        const char ROUND_BRACKET_CLOSE = ')';
        const char SQUARE_BRACKET_OPEN = '[';
        const char SQUARE_BRACKET_CLOSE = ']';
        const char CURLY_BRACKET_OPEN = '{';
        const char CURLY_BRACKET_CLOSE = '}';

        public static bool Validate(string input)
        {
            var stack = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                var item = input[i];
                char prevItem;
                switch (item)
                {
                    case ROUND_BRACKET_OPEN:
                    case SQUARE_BRACKET_OPEN:
                    case CURLY_BRACKET_OPEN:
                        stack.Push(item);
                        break;
                    case ROUND_BRACKET_CLOSE:
                        if (!stack.TryPop(out prevItem) || prevItem != ROUND_BRACKET_OPEN)
                        {
                            return false;
                        }
                        break;
                    case SQUARE_BRACKET_CLOSE:
                        if (!stack.TryPop(out prevItem) || prevItem != SQUARE_BRACKET_OPEN)
                        {
                            return false;
                        }
                        break;
                    case CURLY_BRACKET_CLOSE:
                        if (!stack.TryPop(out prevItem) || prevItem != CURLY_BRACKET_OPEN)
                        {
                            return false;
                        }
                        break;
                }
            }
            return stack.Count == 0;
        }
    }
}
