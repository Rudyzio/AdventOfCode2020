using Day_05_Solver;
using Xunit;
namespace AdventOfCode.Tests
{
    public class Day05Solver_Tests
    {
        [Theory]
        [InlineData("Day05_Input/test1.input", 357)]
        [InlineData("Day05_Input/test2.input", 567)]
        [InlineData("Day05_Input/test3.input", 119)]
        [InlineData("Day05_Input/test4.input", 820)]
        [InlineData("Day05_Input/puzzle.input", 976)]
        public void TestPart1Solution(string inputFile, int expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day05Solver.Part1Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Day05_Input/puzzle.input", 685)]
        public void TestPart2Solution(string inputFile, int expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day05Solver.Part2Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
