using Day_25_Solver;
using Xunit;
namespace AdventOfCode.Tests
{
    public class Day25Solver_Tests
    {
        [Theory]
        [InlineData("Day25_Input/test.input", 14897079)]
        [InlineData("Day25_Input/puzzle.input", 16933668)]	
        public void TestPart1Solution(string inputFile, int expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day25Solver.Part1Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }

        //[Theory]
        //[InlineData("Day25_Input/test.input", 51316)]
        //[InlineData("Day25_Input/puzzle.input", 5142043)]
        public void TestPart2Solution(string inputFile, int expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day25Solver.Part2Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
