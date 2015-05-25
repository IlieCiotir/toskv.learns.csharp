using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versioning
{
    class Program
    {
        static void Main(string[] args)
        {
            ADerived derived = new ADerived();

            Console.WriteLine(derived.AMethod());
            derived.BMethod();

            ABase derivedAsBase = (ABase)derived;

            Console.WriteLine(derivedAsBase.AMethod());
            // return type changes
            Console.WriteLine(derivedAsBase.BMethod());

            // base is a keyword in C# (instead of super, but not always)
            ABase baseO = new ABase();
            
            Console.WriteLine(baseO.AMethod());
            Console.WriteLine(baseO.BMethod());

        }
    }
}
