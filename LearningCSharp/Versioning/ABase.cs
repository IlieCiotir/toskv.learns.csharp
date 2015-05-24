using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Versioning
{
    class ABase
    {
        public virtual string AMethod()
        {
            return "A method";
        }

        public string BMethod()
        {
            return "B method";
        }
    }
}
