using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries
{
    public class Baldrick
    {
        string[] plans = { "Run", "Hide", "Buy turnips" };
        
        public string Plan
        {
            get { return plans[new Random(DateTime.Now.Millisecond).Next(plans.Length)]; }
        }

        public string NextPlan()
        {
            return plans[new Random(DateTime.Now.Millisecond).Next(plans.Length)];
        }
    }
}
