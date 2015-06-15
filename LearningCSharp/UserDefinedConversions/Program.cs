using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDefinedConversions
{
    struct RomanNumeral
    {
        private int value;

        public RomanNumeral(int value) {
            this.value = value;
        }

        static public implicit operator int(RomanNumeral roman)
        {
            return roman.value;
        }

        static public explicit operator RomanNumeral(int value)
        {
            return new RomanNumeral(value);
        }

        static public explicit operator string(RomanNumeral value)
        {
            return "Not implemented";
        }

        static public implicit operator RomanNumeral(MyOtherNumeral num)
        {
            return new RomanNumeral((int) num);
        }
    }

    struct MyOtherNumeral
    {
        private int value;

        public MyOtherNumeral(int value)
        {
            this.value = value;
        }

        static public explicit operator int(MyOtherNumeral num)
        {
            return num.value;
        }
        
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            RomanNumeral num = new RomanNumeral(1231);

            Console.WriteLine((string)num);
            Console.WriteLine((int)num);

            MyOtherNumeral otherNum = new MyOtherNumeral(3213);
            RomanNumeral romNum = otherNum;

            Console.WriteLine((RomanNumeral)otherNum);
            Console.WriteLine(romNum);
        }
    }
}
