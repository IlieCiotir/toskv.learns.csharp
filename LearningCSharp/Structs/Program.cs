using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Structs
{
    struct SimpleStruct
    {
        public int x;

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public override string ToString()
        {   
            // native types have ToString method
            return base.ToString()  + x.ToString();
        }
    }

    class SimpleClass
    {
        private int y;
        
        public void SimpleClas(int y) {
            this.y = y;
        }

        public int Y
        {
            get;
            set;
        }

        public override string ToString()
        {
            return y.ToString();
        }
    }

    // Had to import this manually 
    [StructLayout(LayoutKind.Explicit)]
    struct UnionStruct
    {
        [FieldOffset(0)]
        public int i;
        [FieldOffset(0)]
        public double d;
        [FieldOffset(15)]
        public char c;

    }
    class Program
    {
        static void structChanger(SimpleStruct s)
        {
            s.X = 1000;
            Console.WriteLine("changed struct value is: {0}", s.X);
        }

        static void classChanger(SimpleClass c)
        {
            c.Y = 123;
            Console.WriteLine("changed class value is: {0} ", c.Y);
        }

        static void Main(string[] args)
        {
            SimpleStruct ss =new  SimpleStruct();

            Console.WriteLine(ss);

            ss.X = 20;

            Console.WriteLine(ss.X);

            SimpleStruct ss2;
            // have to use the field, can't set it via a property
            ss2.x = 22;
            Console.WriteLine(ss2);

            SimpleClass sc = new SimpleClass();
            sc.Y = 431;

            structChanger(ss2);
            Console.WriteLine("struct shouldn't be changed here: {0}", ss2.X);

            classChanger(sc);
            Console.WriteLine("class should be changed here: {0}", sc.Y);

            UnionStruct unionStruct = new UnionStruct();
            unionStruct.i = 100;
            unionStruct.d = 123131;
            unionStruct.c = 'q';

            Console.WriteLine("unionStruct.i : {0}", unionStruct.i);
            Console.WriteLine("unionStruct.d : {0}", unionStruct.d);
            Console.WriteLine("unionStruct.c : {0}", unionStruct.c);
            Console.WriteLine(Marshal.SizeOf(ss));
            Console.WriteLine(Marshal.SizeOf(unionStruct));
        }
    }
}
