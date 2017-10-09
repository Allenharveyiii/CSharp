using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_Lab_1_Hackerrank
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthOfArray = int.Parse(Console.ReadLine());
            int smallestNumber = int.MaxValue;
            List<string> strList = new List<string>();
            int[] smallestArray = new int[3]; //Will store the smallest difference and the two coresponding numbers;
            String inputString = Console.ReadLine();
            String[] strinputArray = inputString.Split(' ');
            int[] inputArray = new int[lengthOfArray];
            int count = 0;
            foreach (string s in strinputArray)
            {
                inputArray[count] = int.Parse(s);
                count++;
            }
            Array.Sort(inputArray);

            for (int i = 0; i < lengthOfArray-1; i++)
            {
                int currDistance = Math.Abs(inputArray[i] - inputArray[i + 1]);

                if (currDistance < smallestNumber)
                {
                    strList = new List<string>();
                    strList.Add(inputArray[i]+" "+inputArray[i+1]);
                    smallestNumber = currDistance;
                }
                else if(currDistance == smallestNumber)
                {
                    strList.Add(inputArray[i] + " " + inputArray[i + 1]);
                }
            }
            foreach (string s in strList)
            {
                Console.Write(s+" ");
            }
            Console.ReadKey();
        }
    }
}