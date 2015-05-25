using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionClasses
{
    // everything here is so annoying without method autocomplete from the interfaces
    // using generics for type safety fails to compile :-/
    class InputParser : IEnumerable
    {
        private string[] elements;

        public InputParser(string input, char splitter)
        {
            // type inference isn't that great when creating array to be passed as parameters
            elements = input.Split(new char[]{splitter});
        }

        public IEnumerator GetEnumerator()
        {
            return new InputEnumerator(this);
        }
        
        
        private class InputEnumerator : IEnumerator {
            private int position = -1;
            private InputParser parser;

            public InputEnumerator(InputParser parser)
            {
                this.parser = parser;
            }

            public bool MoveNext()
            {
                if (position < parser.elements.Length - 1)
                {
                    position++;
                    return true;
                }

                return false;
                
            }

            public void Reset()
            {
                position = -1;
            }

            public object Current
            {
                get
                {
                    return parser.elements[position];
                }
            }
        }
    }
    class Program
    {


        static void Main(string[] args)
        {
            InputParser parser  = new InputParser(args[0], ' ');
            foreach(string word in parser) {
                Console.WriteLine(word);
            }
        }
    }
}
