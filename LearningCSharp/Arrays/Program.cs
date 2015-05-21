using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] score = new int[5];
            int[,] names = new int[3, 1];
            int[][] nai = new int[5][];
            for (int x = 0; x < nai.Length; x++)
            {
                int[] values = new int[x];
                for (int y = 0; y < x; y++)
                {
                    values[y] = y;
                }
                nai[x] = values;
            }
            foreach (int[] values in nai)
            {
                foreach (int value in values)
                {
                    Console.Write(value);
                }
                Console.WriteLine();
            }
            Console.WriteLine(nai);

            // Initialization

            // Single dimensional
            int[] grades = new int[] { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine(grades);

            // Multi dimensional
            int[,] numbers = { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 } };
            Console.WriteLine(numbers);

            // Jagged
            int[][] jagged = { new int[] { 1, 3, 4, 5, 6 }, new int[] { 1, 2, 3, 4 } };
            Console.WriteLine(jagged);

            // Itteration
            foreach (int i in grades)
            {
                Console.Write(" {0} ", i);
            }

            Console.WriteLine();

            foreach (int i in numbers)
            {
                Console.Write(" {0} ", i);
            }

            Console.WriteLine();

            foreach (int[] j in jagged)
            {
                foreach (int i in j)
                {
                    Console.Write(" {0} ", i);
                }
            }

            Console.WriteLine();
        }
    }
}
