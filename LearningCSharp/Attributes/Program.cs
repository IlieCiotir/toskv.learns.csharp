using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    [HelpAttribute("http://localhost/MyClassInfo")] // you can add an attribute to it's defining class, neat
    public class HelpAttribute : System.Attribute
    {
        public readonly string Url;

        public string Topic               // Topic is a named parameter
        {
            get
            {
                return topic;
            }
            set
            {

                topic = value;
            }
        }

        public HelpAttribute(string url)  // url is a positional parameter
        {
            this.Url = url;
        }

        private string topic;
    }

    [HelpAttribute("http://localhost/MyClassInfo")]
    class Program
    {
        static void Main(string[] args)
        {
            System.Reflection.MemberInfo info = typeof(HelpAttribute);
            object[] attributes = info.GetCustomAttributes(true);
            for (int i = 0; i < attributes.Length; i++)
            {
                System.Console.WriteLine(attributes[i]);
            }
        }
    }
}
