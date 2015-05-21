using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    class Jedi : Warrior
    {
        private string myAlliance = "N/A";


        public Jedi(string alliance, string name, int age) : base(name, age) {
            this.myAlliance = alliance;
        }


        public override string Alliance
        {
            get { return myAlliance; }
            set { myAlliance = value; }
        }
    }
}
