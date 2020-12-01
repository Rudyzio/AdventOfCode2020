using Day_01_Solver;
using Xunit;
namespace AdventOfCode.Tests
{
    public class Day01Solver_Tests
    {
        [Theory]
        [InlineData("Day01_Input/test.input", 514579)]
        [InlineData("Day01_Input/puzzle.input", 866436)]
        public void TestPart1Solution(string inputFile, int expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day01Solver.Part1Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Day01_Input/test.input", 241861950)]
        [InlineData("Day01_Input/puzzle.input", 276650720)]
        public void TestPart2Solution(string inputFile, int expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day01Solver.Part2Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
