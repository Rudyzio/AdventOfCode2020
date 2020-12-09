using System;
using Common;

namespace Day_08_Solver
{
    public static class Day08Solver
    {
        public static int Part1Solution(string[] lines)
        {
            var bootCode = new BootCodeProgram(lines);
            return bootCode.Run();
        }

        public static int Part2Solution(string[] lines)
        {
            var bootCode = new BootCodeProgram(lines);
            int acc = 0;
            while (true)
            {
                // bootCode.PrintOperations();
                acc = bootCode.Run();
                if (bootCode.IsPointerAttemptingAfterLastInstruction())
                {
                    break;
                }
                bootCode.ChangeNextInstruction();
            }
            return acc;
        }
    }
}
