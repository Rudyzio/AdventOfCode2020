using System;
using System.Collections.Generic;

namespace Day_13_Solver
{
    public static class Day13Solver
    {
        // Part 1 done at first try!!!
        public static int Part1Solution(string[] lines)
        {
            int myDepart = int.Parse(lines[0]);
            int bestBusId = 0;
            int bestBusWaitingTime = 0;

            var buses = lines[1];
            foreach (var bus in buses.Split(","))
            {
                if (!string.Equals(bus, "x"))
                {
                    var currentBusID = int.Parse(bus);
                    int tripsToMyDepart = (int)Math.Ceiling((double)myDepart / (double)currentBusID);
                    int currentWaitingTime = currentBusID * tripsToMyDepart;

                    if (bestBusId == 0 && bestBusWaitingTime == 0)
                    {
                        bestBusId = currentBusID;
                        bestBusWaitingTime = currentWaitingTime - myDepart;
                    }
                    else
                    {
                        if (currentWaitingTime - myDepart < bestBusWaitingTime)
                        {
                            bestBusWaitingTime = currentWaitingTime - myDepart;
                            bestBusId = currentBusID;
                        }
                    }
                }
            }

            return bestBusId * bestBusWaitingTime;
        }

        // Part 2 took a long time to figure it out...
        public static long Part2Solution(string[] lines)
        {
            string[] busesSplitted = lines[0].Split(",");
            long currentTime = 0;
            long inc = long.Parse(busesSplitted[0]);

            for (var i = 1; i < busesSplitted.Length; i++)
            {
                if (!busesSplitted[i].Equals("x"))
                {
                    var currentBusID = long.Parse(busesSplitted[i]);
                    while (true)
                    {
                        currentTime += inc;
                        if ((currentTime + i) % currentBusID == 0)
                        {
                            inc *= currentBusID;
                            break;
                        }
                    }
                    // System.Console.WriteLine($"Time: {currentTime}; Increment: {inc}");
                }
            }

            return currentTime;
        }
    }
}
