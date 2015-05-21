using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties
{
    abstract class Warrior
    {
        private string myName = "N/A";
        private int myAge = 0;

        public Warrior(string name, int age)
        {
            this.myAge = age;
            this.myName = name;
        }

        public string Name
        {
            get
            {
                return myName;
            }
            set
            {
                myName = value;
            }
        }

        public int Age
        {
            get
            {
                return myAge;
            }

            set
            {
                myAge = value;
            }
        }

        public abstract string Alliance
        {
            get;
            set;
        }

        public override string ToString()
        {
            return "Name = " + Name + " Age = " + Age + " Alliance = " + Alliance;
        }
    }
}
