using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Number of arguments: {0} ", args.Length);
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("Args[{0}] = [{1}]", i, args[i]);
            }

            foreach (string s in args.Reverse())
            {
                Console.WriteLine(s);
            }
        }
    }
}
