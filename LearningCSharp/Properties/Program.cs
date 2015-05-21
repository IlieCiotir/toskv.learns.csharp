using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            Warrior warrior = new Jedi("jedi", "T", 100);
            Console.WriteLine(warrior);

            warrior.Age = 4;
            warrior.Name = "Tlatek";
            warrior.Alliance = "Test alliance please ignore";
            Console.WriteLine(warrior);
        }
    }
}
