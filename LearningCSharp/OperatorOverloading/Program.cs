using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloading
{
    public class Complex
    {
        private int real;
        private int imaginary;

        public Complex(int real, int imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }

        static public Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.real + c1.real, c1.imaginary + c2.imaginary);
        }

        static public bool operator !=(Complex c1, Complex c2)
        {
            return c1.real != c2.real || c1.imaginary != c2.imaginary;
        }

        static public Boolean operator ==(Complex c1, Complex c2)
        {
            return !(c1 != c2);
        }

        public override string ToString()
        {
            return String.Format("{0} + {1}i", real, imaginary);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Complex c1 = new Complex(1, 2);
            Complex c2 = new Complex(3, 3);

            Console.WriteLine("c1 = {0}", c1);
            Console.WriteLine("c2 = {0}", c2);

            Complex c3 = c1 + c2;
            Console.WriteLine("c3 = {0}", c3);

            Console.WriteLine("C1 != C3 {0}", c1 != c3);
        }
    }
}
