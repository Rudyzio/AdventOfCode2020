using Day_14_Solver;
using Xunit;
namespace AdventOfCode.Tests
{
    public class Day14Solver_Tests
    {
        [Theory]
        [InlineData("Day14_Input/test.input", 165)]
        [InlineData("Day14_Input/puzzle.input", 14839536808842)]
        public void TestPart1Solution(string inputFile, long expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day14Solver.Part1Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Day14_Input/test2.input", 208)]
        [InlineData("Day14_Input/puzzle.input", 4215284199669)]
        public void TestPart2Solution(string inputFile, long expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day14Solver.Part2Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
