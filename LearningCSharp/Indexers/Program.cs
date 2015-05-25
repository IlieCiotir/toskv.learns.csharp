using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Indexers
{
    public class TextByteArray
    {
        Stream stream;

        public TextByteArray(string input)
        {
            stream = new MemoryStream(Encoding.UTF8.GetBytes(input));
        }

        public byte this[long index]
        {
            get
            {
                byte[] buffer = new byte[1];
                stream.Seek(index, SeekOrigin.Begin);
                stream.Read(buffer, 0, 1);
                return buffer[0];
            }

            set
            {
                stream.Seek(index, SeekOrigin.Begin);
                stream.Write(new byte[] {value}, 0, 1);
            }
        }

        public long Length
        {
            get
            {
                return stream.Seek(0, SeekOrigin.End);
            }
        }

        public override string ToString()
        {
            return stream.ToString();
        }

    }

    // a very complex way of calling string.Reverse
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("provide a string to reverse");
                return;
            }
            TextByteArray text = new TextByteArray(args[0]);
            for (long i = 0; i < text.Length / 2; ++i)
            {
                byte t = text[i];
                text[i] = text[text.Length - i - 1];
                text[text.Length - i - 1] = t;
            }

            for (long i = 0; i < text.Length; ++i)
            {
                Console.Write(Convert.ToChar(text[i]));
            }
        }
    }
}
