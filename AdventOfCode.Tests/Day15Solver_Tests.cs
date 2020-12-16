using Day_15_Solver;
using Xunit;
namespace AdventOfCode.Tests
{
    public class Day15Solver_Tests
    {
        [Theory]
        [InlineData("Day15_Input/test1.input", 436)]
        [InlineData("Day15_Input/test2.input", 1)]
        [InlineData("Day15_Input/test3.input", 10)]
        [InlineData("Day15_Input/test4.input", 27)]
        [InlineData("Day15_Input/test5.input", 78)]
        [InlineData("Day15_Input/test6.input", 438)]
        [InlineData("Day15_Input/test7.input", 1836)]
        [InlineData("Day15_Input/puzzle.input", 959)]
        public void TestPart1Solution(string inputFile, int expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day15Solver.Part1Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Day15_Input/test1.input", 175594)]
        [InlineData("Day15_Input/test2.input", 2578)]
        [InlineData("Day15_Input/test3.input", 3544142)]
        [InlineData("Day15_Input/test4.input", 261214)]
        [InlineData("Day15_Input/test5.input", 6895259)]
        [InlineData("Day15_Input/test6.input", 18)]
        [InlineData("Day15_Input/test7.input", 362)]
        [InlineData("Day15_Input/puzzle.input", 116590)]
        public void TestPart2Solution(string inputFile, int expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day15Solver.Part2Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
