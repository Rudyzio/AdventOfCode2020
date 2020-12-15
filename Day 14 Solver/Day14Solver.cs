using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Day_14_Solver
{
    public static class Day14Solver
    {
        public static long Part1Solution(string[] lines)
        {
            long toReturn = 0;
            var mask = string.Empty;
            Dictionary<int, string> memory = new Dictionary<int, string>();
            foreach (var line in lines)
            {
                if (line.Contains("mask"))
                {
                    mask = line.Split(" ")[2];
                }
                else
                {
                    var splitted = line.Split(" ");
                    var value = int.Parse(splitted[2]);

                    int from = splitted[0].IndexOf("[") + "[".Length;
                    int to = splitted[0].LastIndexOf("]");

                    var position = int.Parse(splitted[0].Substring(from, to - from));
                    string binary = Convert.ToString(value, 2).PadLeft(36, '0');
                    binary = ApplyMask(binary, mask, 'X');

                    if (!memory.ContainsKey(position))
                    {
                        memory.Add(position, binary);
                    }
                    else
                    {
                        memory[position] = binary;
                    }
                }
            }

            foreach (var mem in memory)
            {
                toReturn += Convert.ToInt64(mem.Value, 2);
            }

            return toReturn;
        }

        public static long Part2Solution(string[] lines)
        {
            long toReturn = 0;
            var mask = string.Empty;
            Dictionary<long, string> memory = new Dictionary<long, string>();
            foreach (var line in lines)
            {
                if (line.Contains("mask"))
                {
                    mask = line.Split(" ")[2];
                }
                else
                {
                    var splitted = line.Split(" ");
                    var value = int.Parse(splitted[2]);

                    int from = splitted[0].IndexOf("[") + "[".Length;
                    int to = splitted[0].LastIndexOf("]");

                    var position = int.Parse(splitted[0].Substring(from, to - from));
                    var positionBinary = Convert.ToString(position, 2).PadLeft(36, '0');
                    string binary = Convert.ToString(value, 2).PadLeft(36, '0');
                    var result = ApplyMask(positionBinary, mask, '0');
                    var positions = GetAllCombinations(result);

                    foreach (var pos in positions)
                    {
                        long integerPosition = Convert.ToInt64(pos, 2);
                        if (!memory.ContainsKey(integerPosition))
                        {
                            memory.Add(integerPosition, binary);
                        }
                        else
                        {
                            memory[integerPosition] = binary;
                        }
                    }
                }
            }

            foreach (var mem in memory)
            {
                toReturn += Convert.ToInt64(mem.Value, 2);
            }

            return toReturn;
        }

        private static string ApplyMask(string binary, string mask, char ignoreChar)
        {
            // System.Console.WriteLine("========================== Applying mask ==========================");
            // System.Console.WriteLine($"value:    {binary} (decimal {Convert.ToInt64(binary, 2)})");
            // System.Console.WriteLine($"mask:     {mask}");
            StringBuilder toReturn = new StringBuilder(binary);
            for (var i = 0; i < binary.Length; i++)
            {
                if (mask[i] != ignoreChar)
                {
                    toReturn[i] = mask[i];
                }
                else
                {
                    toReturn[i] = binary[i];
                }
            }
            // if (ignoreChar == 'X')
            // {
            //     System.Console.WriteLine($"result:   {toReturn.ToString()} (decimal {Convert.ToInt64(toReturn.ToString(), 2)})");
            // }
            // if (ignoreChar == '0')
            // {
            //     System.Console.WriteLine($"result:   {toReturn.ToString()}");
            // }
            // System.Console.WriteLine();
            return toReturn.ToString();
        }

        private static List<string> GetAllCombinations(string binary)
        {
            var toReturn = new List<string>();
            var xAmount = binary.Count(x => x == 'X');
            var combinations = Math.Pow(2, xAmount);
            for (int i = 0; i < combinations; i++)
            {
                var str = Convert.ToString(i, 2).PadLeft(xAmount, '0');
                StringBuilder newCombination = new StringBuilder(binary);
                var currentOccurrence = 0;
                for (int j = 0; j < binary.Length; j++)
                {
                    if (binary[j] == 'X')
                    {
                        newCombination[j] = str[currentOccurrence];
                        currentOccurrence++;
                    }
                    else
                    {
                        newCombination[j] = binary[j];
                    }
                }
                toReturn.Add(newCombination.ToString());
                // System.Console.WriteLine($"{newCombination.ToString()} (decimal {Convert.ToInt64(newCombination.ToString(), 2)})");
            }
            // System.Console.WriteLine();
            return toReturn;
        }
    }
}
