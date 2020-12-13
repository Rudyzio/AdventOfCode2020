using Day_13_Solver;
using Xunit;
namespace AdventOfCode.Tests
{
    public class Day13Solver_Tests
    {
        [Theory]
        [InlineData("Day13_Input/test.input", 295)]
        [InlineData("Day13_Input/puzzle.input", 2215)]
        public void TestPart1Solution(string inputFile, int expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day13Solver.Part1Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Day13_Input/test1.input", 1068781)]
        [InlineData("Day13_Input/test2.input", 3417)]
        [InlineData("Day13_Input/test3.input", 754018)]
        [InlineData("Day13_Input/test4.input", 779210)]
        [InlineData("Day13_Input/test5.input", 1261476)]
        [InlineData("Day13_Input/test6.input", 1202161486)]
        [InlineData("Day13_Input/puzzle2.input", 1058443396696792)]
        public void TestPart2Solution(string inputFile, long expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day13Solver.Part2Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
