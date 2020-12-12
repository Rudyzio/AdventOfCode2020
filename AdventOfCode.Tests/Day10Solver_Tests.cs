using Day_10_Solver;
using Xunit;
namespace AdventOfCode.Tests
{
    public class Day10Solver_Tests
    {
        [Theory]
        [InlineData("Day10_Input/test1.input", 35)]
        [InlineData("Day10_Input/test2.input", 220)]
        [InlineData("Day10_Input/puzzle.input", 1820)]	
        public void TestPart1Solution(string inputFile, int expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day10Solver.Part1Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Day10_Input/test1.input", 8)]
        [InlineData("Day10_Input/test2.input", 19208)]
        [InlineData("Day10_Input/puzzle.input", 3454189699072)]
        public void TestPart2Solution(string inputFile, long expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day10Solver.Part2Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
