using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConditionalMethods
{
    public class Log
    {
        [Conditional("DEBUG")]
        public static void DebugMessage(string message)
        {
            Console.WriteLine("[TRACE] : {0}", message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Log.DebugMessage("message");
            
        }
    }
}
