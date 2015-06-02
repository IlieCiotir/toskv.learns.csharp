using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace PlatformInvoke
{
    class Program
    {
        [DllImport("msvcrt.dll")]
        [return: MarshalAs(UnmanagedType.I4)]
        public static extern int puts([MarshalAs(UnmanagedType.LPStr)] string c);

        [DllImport("msvcrt.dll")]
        internal static extern int _flushall();

        static void Main(string[] args)
        {
            puts("Let's print some text!");
            _flushall();
        }
    }
}
