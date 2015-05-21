using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Libraries;

namespace LibrariesClient
{
    class BlackAdder
    {
        static void Main(string[] args)
        {
            Baldrick baldrick = new Baldrick();
            
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Go on Baldrick what's your plan?");
                Console.WriteLine(baldrick.Plan);
            }
                
        }
    }
}
