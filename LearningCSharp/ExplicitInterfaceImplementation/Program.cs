using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExplicitInterfaceImplementation
{
    class Program
    {
        public interface IMyInterface
        {
            string My1stMethod();
            int My2ndMethod();
        }

        public interface IMyOtherInterface
        {
            string My1stMethod();
            int My2ndMethod();
        }

        public class Implementation : IMyInterface, IMyOtherInterface
        {
            private string tag;
            private int number;

            public Implementation(string tag, int number)
            {
                this.tag = tag;
                this.number = number;
            }

            public string My1stMethod()
            {
                return tag + " not boxed";
            }

            int IMyOtherInterface.My2ndMethod()
            {
                return number + 100;
            }

            string IMyInterface.My1stMethod()
            {
                return tag;
            }

            int IMyInterface.My2ndMethod()
            {
                return number;
            }
        }
        static void Main(string[] args)
        {
            Implementation impl = new Implementation("a tag", 123);

            Console.WriteLine(impl.My1stMethod());

            IMyInterface boxedObject = (IMyInterface)impl;

            Console.WriteLine(boxedObject.My1stMethod());
            Console.WriteLine(boxedObject.My2ndMethod());

            IMyOtherInterface boxedOther = (IMyOtherInterface)impl;
            Console.WriteLine(boxedOther.My2ndMethod());

        }
    }
}
