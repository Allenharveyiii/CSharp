using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Numerics;

/// <summary>
/// This excersise is used to model different rates of growth.
/// Used to anailize the growths and to further understand the impact they have on run times.
/// </summary>
namespace AlgoLab2
{
    class Program
    {
        /// <summary>
        /// Main executing method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            BigInteger n = 0;
            
            while (n!=-1)
            {

                Console.WriteLine("Please enter a number: ");
                n = BigInteger.Parse(Console.ReadLine());
                Stopwatch sw = Stopwatch.StartNew(); //creates sw and starts stopwatch
                //nsquaredgrowthversion1(n);
                //ngrowth(n);
                //ncubedgrowth(n);
                //ntothefourthgrowth(n);
                //twotothengrowth(n);
                //nfactorialgrowth(n);
                nlgngrowth(n);
                sw.Stop(); // stops stopwatch
                Console.WriteLine("Time used: {0} secs", sw.Elapsed.TotalMilliseconds / 1000);
            }
            
        }
        //Models n^2 growth
        private static void nsquaredgrowthversion1(int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    //sum = sum + 1;
                    //sum++;
                    //sum = sum + 31;
                    sum += 1;
        }
        //Models n growth or linear grownth
        private static void ngrowth(long n)
        {
            long sum = 0;
            for (long i = 0; i < n; i++)
            {
                sum++;
            }
        }
        //Models n^3 Growth
        private static void ncubedgrowth(int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        sum++;
                    }
                }
            }
        }
        /// <summary>
        /// Models n^4 growth
        /// </summary>
        /// <param name="n"></param>
        private static void ntothefourthgrowth(int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        for (int l = 0; l < n; l++)
                        {
                            sum++;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Models 2^n Growth
        /// </summary>
        /// <param name="n"></param>
        private static void twotothengrowth(long n)
        {
            ngrowth((long)Math.Pow(2,n));
        }

        /// <summary>
        /// Models n! growth
        /// </summary>
        /// <param name="n"></param>
        private static void nfactorialgrowth(long n)
        {
            long result=n;
            for (int i = 1; i < n; i++)
            {
                result = result * i;
            }
            
            ngrowth(result);
        }

        /// <summary>
        /// Models lgn Growth
        /// </summary>
        /// <param name="n"></param>
        private static void lgngrowth(BigInteger n)
        {
            while (n !=1)
            {
                n = n / 2;
            }
        }

        /// <summary>
        /// Models nlgn growth
        /// </summary>
        /// <param name="n"></param>
        private static void nlgngrowth(BigInteger n)
        {
            for (BigInteger i = 0; i < n; i++)
            {
                lgngrowth(n);
            }
        }

    }
}
