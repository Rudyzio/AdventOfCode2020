using System.Collections.Generic;

namespace Day_18_Solver
{
    public static class Day18Solver
    {
        public static long Part1Solution(string[] lines)
        {
            // Shunting Yard Algorithm inspiration
            long toReturn = 0;
            Stack<long> numbers = new Stack<long>();
            Stack<char> operations = new Stack<char>();

            foreach (var line in lines)
            {
                operations.Push('(');
                foreach (var character in line)
                {
                    switch (character)
                    {
                        case ' ':
                            break;
                        case '(':
                            operations.Push(character);
                            break;
                        case ')':
                            Calculate(numbers, operations, "(");
                            operations.Pop();
                            break;
                        case '+':
                            Calculate(numbers, operations, "(");
                            operations.Push(character);
                            break;
                        case '*':
                            Calculate(numbers, operations, "(");
                            operations.Push(character);
                            break;
                        // Is a number
                        default:
                            var nextNumber = int.Parse(character.ToString());
                            numbers.Push(nextNumber);
                            break;
                    }
                }
                Calculate(numbers, operations, "(");
                toReturn += numbers.Pop();
            }

            return toReturn;
        }


        public static long Part2Solution(string[] lines)
        {
            long toReturn = 0;
            Stack<long> numbers = new Stack<long>();
            Stack<char> operations = new Stack<char>();

            foreach (var line in lines)
            {
                operations.Push('(');
                foreach (var character in line)
                {
                    switch (character)
                    {
                        case ' ':
                            break;
                        case '(':
                            operations.Push(character);
                            break;
                        case ')':
                            Calculate(numbers, operations, "(");
                            operations.Pop();
                            break;
                        case '+':
                            Calculate(numbers, operations, "(*");
                            operations.Push(character);
                            break;
                        case '*':
                            Calculate(numbers, operations, "(");
                            operations.Push(character);
                            break;
                        // Is a number
                        default:
                            var nextNumber = int.Parse(character.ToString());
                            numbers.Push(nextNumber);
                            break;
                    }
                }
                Calculate(numbers, operations, "(");
                toReturn += numbers.Pop();
            }
            return toReturn;
        }

        private static void Calculate(Stack<long> numbers, Stack<char> operations, string until)
        {
            while (!until.Contains(operations.Peek()))
            {
                var operation = operations.Pop();
                var firstOperand = numbers.Pop();
                var secondOperand = numbers.Pop();
                switch (operation)
                {
                    case '+':
                        // System.Console.WriteLine($"{firstOperand} + {secondOperand} = {firstOperand + secondOperand}");
                        numbers.Push(firstOperand + secondOperand);
                        break;
                    case '*':
                        // System.Console.WriteLine($"{firstOperand} * {secondOperand} = {firstOperand * secondOperand}");
                        numbers.Push(firstOperand * secondOperand);
                        break;
                }
            }
        }


    }
}
