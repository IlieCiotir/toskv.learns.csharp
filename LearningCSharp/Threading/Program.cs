using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Threading
{
    class Ilie
    {
        public void Speak()
        {
            while (true)
            {
                Console.WriteLine("Mhm, working on a different thread.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Threading examle");
            Ilie cili = new Ilie();
            Thread oThread = new Thread(new ThreadStart(cili.Speak));

            oThread.Start();

            // Wait for Ilie to wake up
            while (!oThread.IsAlive) ;

            
            // Let Ilie speak a big
            Thread.Sleep(10);
            Console.WriteLine("Ilie that's enough!");
            // He's had enough time to put a stop to this
            oThread.Abort();

            // Ilie doesn't stop speaking immediately, we'll have to wait for a bit
            oThread.Join();

            Console.WriteLine("OMG he's done");

            try
            {
                // lets try giving letting Ilie speak again
                Console.WriteLine("Ilie do you have more to say?");
                oThread.Start();
            } catch(ThreadStateException) {
                Console.WriteLine("Ilie would rather not take any more of your time with his chatter.");
            }
        }
    }
}
