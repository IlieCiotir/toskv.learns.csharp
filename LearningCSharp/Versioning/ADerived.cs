using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versioning
{
    class ADerived : ABase
    {
        public override string AMethod()
        {
            return "A derived";
        }

        public new void BMethod()
        {
            System.Console.WriteLine("B method new");
        }
    }
}
