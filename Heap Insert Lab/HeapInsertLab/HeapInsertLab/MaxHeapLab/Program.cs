using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapInsertLab
{
    class Program
    {
        /// <summary>
        /// The heap
        /// </summary>
        private static MaxHeap heap;

        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            runHeapTest();
        }

        /// <summary>
        /// Runs the heap test.
        /// </summary>
        static void runHeapTest()
        {
            int numberOfEntries;

            Console.WriteLine("Input the number of strings you would like to put in.\n");
            numberOfEntries = int.Parse(Console.ReadLine());

            heap = new MaxHeap(numberOfEntries);

            for (int i = 1; i <= numberOfEntries; i++)
            {
                heap.Insert(Console.ReadLine());
            }
            heap.Print();
            Console.ReadKey();
        }
    }
}
