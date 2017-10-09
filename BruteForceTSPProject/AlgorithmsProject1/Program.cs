/*******************************************************************
*   Author: Allen Watson
*   Email: Watsonah@etsu.edu
*   Project: Algorithms Project 1
*   Program: Program.cs
********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics;

namespace AlgorithmsProject1
{
    class Program
    {
        private static int[] currentPerm;
        private static double[,] distanceArray;
        private static int[,] pointArray;
        private static double shortestDistance = double.MaxValue;
        /// <summary>
        /// Main method; Used to start program execution
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            //used to get points into int arrays.
            int num = int.Parse(Console.ReadLine());
            currentPerm = new int[num];
            pointArray = new int[num + 1, 2];
            distanceArray = new double[num + 1, num + 1];
            for (int i = 1; i <= num; i++)
            {
                currentPerm[i - 1] = i;
                char[] separator = new char[] { ' ' };
                string[] strArray = Console.ReadLine().Split(separator);
                pointArray[i, 0] = int.Parse(strArray[0]);
                pointArray[i, 1] = int.Parse(strArray[1]);
            }
            //Most of work is done here.
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            computePerm(currentPerm, 0);
            //Outputing shorest distance to the screen.
            Console.WriteLine(shortestDistance);
            stopwatch.Stop();
            Console.WriteLine("Time used: {0} secs", stopwatch.Elapsed.TotalMilliseconds / 1000.0);
            Console.WriteLine("DONE");
            Console.ReadLine();
        }

        /// <summary>
        /// Used to get the next permiutation of the points
        /// </summary>
        /// <param name="intArray">Starting permiutation</param>
        /// <param name="iterator">Number to iterate on</param>
        private static void computePerm(int[] intArray, int iterator)
        {
            for (int i = iterator; i < intArray.Length; i++)
            {
                exchange(i, iterator, intArray);
                int ceiling = (int)(((double)intArray.Length) / 2.0);
                if (ceiling < (((double)intArray.Length) / 2.0)) ceiling++;
                if (intArray[0] > ceiling)
                {
                    return;
                }
                computePerm(intArray, iterator + 1);
                exchange(iterator, i, intArray);
                ceiling = (int)(((double)intArray.Length) / 2.0);
                if (ceiling < (((double)intArray.Length) / 2.0)) ceiling++;
                if (intArray[0] > ceiling)
                {
                    return;
                }
            }
            if (iterator == (intArray.Length - 1))
            {
                int[] array = new int[intArray.Length];
                intArray.CopyTo(array, 0);
                calculateDistance(array);
            }
        }

        /// <summary>
        /// Used to calculate the total distance of a permiutation
        /// </summary>
        /// <param name="intArray"></param>
        private static void calculateDistance(int[] intArray)
        {
            double num = 0.0;
            num = distanceFormula(0, 0, pointArray[intArray[0], 0], pointArray[intArray[0], 1]);
            for (int i = 1; i < intArray.Length; i++)
            {
                if (num > shortestDistance)
                {
                    break;
                }
                if ((distanceArray[intArray[i - 1], intArray[i]] != 0.0) || (distanceArray[intArray[i], intArray[i - 1]] != 0.0))
                {
                    num += distanceArray[intArray[i - 1], intArray[i]];
                }
                else
                {
                    double num3 = 0.0;
                    num3 = distanceFormula(pointArray[intArray[i - 1], 0], pointArray[intArray[i - 1], 1], pointArray[intArray[i], 0], pointArray[intArray[i], 1]);
                    distanceArray[intArray[i - 1], intArray[i]] = num3;
                    distanceArray[intArray[i], intArray[i - 1]] = num3;
                    num += num3;
                }
            }
            num += distanceFormula(pointArray[intArray[intArray.Length - 1], 0], pointArray[intArray[intArray.Length - 1], 1], 0, 0);
            if (num < shortestDistance)
            {
                shortestDistance = num;
            }
        }
        /// <summary>
        /// Used to calculate the distance between two individual points.
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        private static double distanceFormula(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt((((double)(x2 - x1) * (double)(x2 - x1)) + ((double)(y2 - y1) * (double)(y2 - y1))));
        }

        /// <summary>
        /// Used to exchange the positions of two points in the point array.
        /// </summary>
        /// <param name="indexOfExchage1"></param>
        /// <param name="indexOfExchange2"></param>
        /// <param name="permArray"></param>
        private static void exchange(int indexOfExchage1, int indexOfExchange2, int[] permArray)
        {
            int num = 0;
            num = permArray[indexOfExchage1];
            permArray[indexOfExchage1] = permArray[indexOfExchange2];
            permArray[indexOfExchange2] = num;
        }
    }
}
