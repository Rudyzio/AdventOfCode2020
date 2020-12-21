using Day_19_Solver;
using Xunit;
namespace AdventOfCode.Tests
{
    public class Day19Solver_Tests
    {
        [Theory]
        [InlineData("Day19_Input/test.input", 2)]
        [InlineData("Day19_Input/test2.input", 3)]
        [InlineData("Day19_Input/puzzle.input", 182)]	
        public void TestPart1Solution(string inputFile, int expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day19Solver.Part1Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Day19_Input/test2.input", 12)]
        [InlineData("Day19_Input/puzzle.input", 334)]
        public void TestPart2Solution(string inputFile, int expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day19Solver.Part2Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
