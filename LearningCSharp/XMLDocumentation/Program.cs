/// XmlDocumentation.cs
/// compile with: /doc:XmlDocumentation.xml
/// Or just check the box in project properties Build tab.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLDocumentation
{
    /// <summary>
    /// Class level summary documentation goes here.</summary>
    /// <remarks>
    /// My remarks are that I like java style of documentation more.</remarks>
    class Program
    {
        /// <summary>
        /// my pretty member!
        /// </summary>
        private string someMember;

        /// <summary>
        /// Great at doing nothing!
        /// </summary>
        public Program()
        {

        }

        /// <summary>
        /// Uh look another property
        /// </summary>
        /// <value>
        /// It has a very useful value.
        /// </value>
        public string AnotherProperty
        {
            get;
            set;
        }

        /// <summary>
        /// This is a documented method
        /// </summary>
        /// <param name="s">hey this is generated automatically!</param>
        /// <returns>A number! Somehow related to the input.</returns>
        /// <seealso cref="String">
        /// Go look at this too!
        /// </seealso>
        public int PrettyMethod(string s)
        {
            return s.Length;
        }

        /// <summary>
        /// The main method.
        /// </summary>
        /// <param name="args">Typy typy!</param>
        static void Main(string[] args)
        {
        }
    }
}
