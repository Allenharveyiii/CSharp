// ---------------------------------------------------------------------------
// File name: Program.cs
// Project name:AlgoProject2
// ---------------------------------------------------------------------------
// Creator’s name and email:	Allen Watson, allen.watson.iii@gmail.com					
// Course-Section: 001
//	Creation Date:	
// ---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics;

namespace AlgoProject2
{
    class Program
    {
        /// <summary>
        /// Main Program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            //creating arrays
            int[] x1, y1, x2, y2;
            int numberOfCases, numberOfCookies;

            //gets the number of test cases needing to be ran
            numberOfCases = int.Parse(Console.ReadLine());
            while (numberOfCases != 0)
            {
                //gets the number of cookies there is going to be
                numberOfCookies = int.Parse(Console.ReadLine());
                //creating the point arrays
                x1 = new int[numberOfCookies];
                y1 = new int[numberOfCookies];
                x2 = new int[numberOfCookies];
                y2 = new int[numberOfCookies];

                sw.Start();
                //used to put all the cookies into the array
                for (int i = 0; i < numberOfCookies; i++)
                {
                    string pointSet = Console.ReadLine();
                    string[] points = pointSet.Split(' ');
                    x1[i] = int.Parse(points[0]);
                    y1[i] = int.Parse(points[1]);
                }
                //used to copy and sort the arrays.
                Array.Copy(x1, x2, x2.Length);
                Array.Copy(y1, y2, y1.Length);
                Array.Sort(x1, y1);
                Array.Sort(y2, x2);
                
                //used to get the lines 
                int[] yline = y2.Distinct().ToArray();
                int[] xline = x1.Distinct().ToArray();
                int brendaMinMax = 999999;
                int currentBrendaMax = 0;

                //start of the solving loop
                //xlines
                for (int i = 0; i < xline.Length+1; i++)
                {
                    double currentXLine = 0;
                    //used to force the first x line to be zero
                    if (i == 0)
                    {}
                    else
                        currentXLine = xline[i-1] + .5;
                    currentBrendaMax = 0;
                    //inner y loop
                    for (int j = 0; j < yline.Length+1; j++)
                    {
                        //check where the points are.
                        
                        double currentYLine = 0;
                        //used to force the first y line to be zero
                        if (j == 0)
                        { }
                        else
                            currentYLine = yline[j-1] + .5;

                        //used to store the number of cookies in brenda's quadrants
                        int botRightCookies = 0;
                        int topLeftCookies = 0;

                        //used to find which cookies where in which quadrant
                        for (int k = 0; k < numberOfCookies; k++)
                        {
                            if (y2[k] < currentYLine && x2[k] > currentXLine)
                            {
                                botRightCookies++;
                            }
                            else if (y2[k] > currentYLine && x2[k] < currentXLine)
                            {
                                topLeftCookies++;
                            }
                        }
                        //used to see if this set opf cookies was the max set brenda could get with this x line.
                        if ((topLeftCookies + botRightCookies) > currentBrendaMax && (topLeftCookies + botRightCookies)!= 0)
                            currentBrendaMax = topLeftCookies + botRightCookies;
                    }
                    //used to find the minimum max of brenda's amount of cookies
                    if (currentBrendaMax < brendaMinMax && currentBrendaMax != 0)
                    {
                        brendaMinMax = currentBrendaMax;
                    }
                }
                Console.WriteLine("\nAnnies' max cookies are: "+(numberOfCookies - brendaMinMax));
                numberOfCases--;
            }
            sw.Stop();
            Console.WriteLine("\nTime used: {0} secs", sw.Elapsed.TotalMilliseconds / 1000);
        }
    }
}
