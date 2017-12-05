using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapInsertLab
{
    class MaxHeap
    {
        private int max_size;           //max size of heap, this is included just to explain that size is not maximum size, but is current heap size.
        public int size{ get; private set; }               //size of current heap
        private string[] h;             //array of strings that the heap will use


        /// <summary>
        /// Initializes a new instance of the <see cref="MaxHeap"/> class.
        /// </summary>
        /// <param name="max_size">The max_size.</param>
        public MaxHeap(int max_size)
        {
            this.size = 0;
            this.max_size = max_size + 1;
            this.h = new string[this.max_size];
        }

        /// <summary>
        /// Prints the heap.
        /// </summary>
        public void Print()
        {
            for (int i = 1; i < this.max_size; i++)
            {
                Console.Write(h[i]+" ");
            }
        }

        /// <summary>
        /// Inserts the specified item into the heap.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Insert(string item)
        {
            h[++this.size] = item;

            if (this.size > 1)
            {
                int currentParent = parent(size);
                int currentChild = size;
                //We know that the current size is the index of the currently inputed string
                while (String.CompareOrdinal(h[currentParent], h[currentChild]) < 0 && currentParent != 0)
                {
                    Swap(currentParent, currentChild);
                    currentChild = currentParent;
                    currentParent = parent(currentChild);
                }
            }
        }

        /// <summary>
        /// Parents the specified current postiton.
        /// </summary>
        /// <param name="currentPostiton">The current postiton.</param>
        /// <returns></returns>
        private int parent(int currentPostiton)
        {
            return currentPostiton / 2;
        }

        /// <summary>
        /// Swaps the specified parent position.
        /// </summary>
        /// <param name="parentPosition">The parent position.</param>
        /// <param name="currentPosition">The current position.</param>
        private void Swap(int parentPosition, int currentPosition)
        {
            string temp = h[parentPosition];
            h[parentPosition] = h[currentPosition];
            h[currentPosition] = temp;
        }



    }
}
