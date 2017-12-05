using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Numerics;
using System.IO;

namespace MergeSortLab
{
    /// <summary>
    /// Main executing method
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            double[] inputArray = new double[int.Parse(Console.ReadLine())];

            for (int i = 0; i < inputArray.Length; i++)
            {
                inputArray[i] = double.Parse(Console.ReadLine());
            }


            Stopwatch sw = Stopwatch.StartNew(); //creates sw and starts stopwatch

            double[] outputArray = MergeSort(inputArray);

            sw.Stop(); // stops stopwatch

            Console.WriteLine("Time used: {0} secs", sw.Elapsed.TotalMilliseconds / 1000);

            foreach (double d in outputArray)
            {
                Console.WriteLine(""+d);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="B">Array of doubles</param>
        /// <param name="C">Array of doubles</param>
        /// <returns></returns>
        private static double[] Merge(double[] B, double[] C)
        {
            double[] mergedArray = new double[B.Length + C.Length];

            for (int bCount = 0, cCount = 0, mCount = 0; mCount < mergedArray.Length;)
            {
                if (bCount  == B.Length)
                {
                    for (int i = cCount; i < C.Length && mCount < mergedArray.Length; i++)
                    {
                        mergedArray[mCount] = C[i];
                        mCount++;
                    }
                }
                else if (cCount == C.Length)
                {
                    for (int i = bCount; i < B.Length && mCount < mergedArray.Length; i++)
                    {
                        mergedArray[mCount] = B[i];
                        mCount++;
                    }
                }
                else if (B[bCount] < C[cCount])
                {
                    mergedArray[mCount] = B[bCount];
                    mCount++;
                    bCount++;
                }
                else if (B[bCount] > C[cCount])
                {
                    mergedArray[mCount] = C[cCount];
                    mCount++;
                    cCount++;
                }
                else
                {
                    mergedArray[mCount] = B[bCount];
                    mCount++;
                    bCount++;
                    mergedArray[mCount] = C[cCount];
                    mCount++;
                    cCount++;
                }

            }
            return mergedArray;
        }

        /// <summary>
        /// Calls merge recursively and returns sorted array
        /// </summary>
        /// <param name="A">Double array</param>
        /// <returns>Sorted double array</returns>
        private static double[] MergeSort(double[] A)
        {
            double[] mergeSortedArray = new double[A.Length];

            if (A.Length == 1)
                return A;
            mergeSortedArray = Merge(MergeSort(A.Take(A.Length/2).ToArray()),MergeSort(A.Skip(A.Length/2).ToArray()));

            return mergeSortedArray;
        }
    }
}
