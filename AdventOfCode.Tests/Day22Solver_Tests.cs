using Day_22_Solver;
using Xunit;
namespace AdventOfCode.Tests
{
    public class Day22Solver_Tests
    {
        [Theory]
        [InlineData("Day22_Input/test.input", 306)]
        [InlineData("Day22_Input/puzzle.input", 32448)]	
        public void TestPart1Solution(string inputFile, int expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day22Solver.Part1Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Day22_Input/test.input", 291)]
        [InlineData("Day22_Input/puzzle.input", 32949)]
        public void TestPart2Solution(string inputFile, int expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day22Solver.Part2Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
