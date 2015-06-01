using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IndexedProperties
{
    public class StringIndexer
    {
        public class CharacterByteArray
        {

        }
        public class TextByteArray
        {
            Stream stream;

            public TextByteArray(Stream stream)
            {
                this.stream = stream;
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
                    stream.Write(new byte[] { value }, 0, 1);
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


        readonly Stream stream;

        public StringIndexer(string input)
        {
            stream = new MemoryStream(Encoding.UTF8.GetBytes(input));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
