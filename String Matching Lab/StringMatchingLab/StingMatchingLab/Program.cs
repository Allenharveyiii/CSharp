using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StingMatchingLab
{
    class Program
    {
        /// <summary>
        /// Main program implementing KMP algorithm
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //string strT = "bacbabababacaca";
            //string strP = "ababaca";
            Console.WriteLine("Enter Text:");
            string text = Console.ReadLine();
            Console.WriteLine("Enter Pattern:");
            string pattern = Console.ReadLine();

            KMPMatcher2(text, pattern);
            Console.ReadKey();

            /*Console.WriteLine("Please enter a string:");
            string strMatching = Console.ReadLine();

            int[] pi = ComputePrefixFunction(strMatching);


            Console.Write("Pi = ");
            foreach (int item in pi)
            {
                Console.Write(item + " ");
            }
            Console.ReadLine();*/


        }

        /// <summary>
        /// USed to compute pi.
        /// </summary>
        /// <param name="P">The pattern entered by the user</param>
        /// <returns></returns>
        private static int[] ComputePrefixFunction(string P)
        {
            int[] pi = new int[P.Length];
            pi[0] = 0;
            int k = 0;
            int q = 1;
            int m = P.Length;

            while (q < m)
            {
                if (k == 0 && P[k] != P[q])
                {
                    pi[q] = 0;
                    q++;
                }
                else if (P[k] == P[q])
                {
                    k++;
                    pi[q] = k;
                    q++;
                }
                else
                {
                    k = pi[k - 1];
                }
            }
            return pi;
        }

        /// <summary>
        /// Used to display the shift at which the pattern matches a portion of the text
        /// </summary>
        /// <param name="tString">The text entered by the user</param>
        /// <param name="pString">The pattern entered by the user</param>
        private static void KMPMatcher2(string tString, string pString)
        {
            int tLength = tString.Length;
            int pLength = pString.Length;
            int txtIndex = 0;
            int patternIndex = 0;
            int[] pi = ComputePrefixFunction(pString);
            //int numOfCharMatches = 0;  //number of character matches

            while (txtIndex < tLength) //while the index is less than the length of the text
            {
                if (pString[patternIndex] == tString[txtIndex]) //comparing a character in the pattern to a character in the text.
                {
                    patternIndex++;
                    txtIndex++;
                }
                if (patternIndex == pLength) //if the entire pattern has been matched
                {
                    Console.WriteLine("Pattern occurs with shift " + (txtIndex - patternIndex));
                    patternIndex = pi[patternIndex - 1];
                }
                else if (txtIndex < tLength && pString[patternIndex] != tString[txtIndex]) //
                {
                    if (patternIndex != 0)
                        patternIndex = pi[patternIndex - 1];
                    else
                        txtIndex = txtIndex + 1;
                }
            }

        }
    }
}
