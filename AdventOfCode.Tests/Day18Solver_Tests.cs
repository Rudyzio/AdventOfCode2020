using Day_18_Solver;
using Xunit;
namespace AdventOfCode.Tests
{
    public class Day18Solver_Tests
    {
        [Theory]
        [InlineData("Day18_Input/test1.input", 71)]
        [InlineData("Day18_Input/test2.input", 51)]
        [InlineData("Day18_Input/test3.input", 26)]
        [InlineData("Day18_Input/test4.input", 437)]
        [InlineData("Day18_Input/test5.input", 12240)]
        [InlineData("Day18_Input/test6.input", 13632)]
        [InlineData("Day18_Input/puzzle.input", 4940631886147)]	
        public void TestPart1Solution(string inputFile, long expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day18Solver.Part1Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Day18_Input/test1.input", 231)]
        [InlineData("Day18_Input/test2.input", 51)]
        [InlineData("Day18_Input/test3.input", 46)]
        [InlineData("Day18_Input/test4.input", 1445)]
        [InlineData("Day18_Input/test5.input", 669060)]
        [InlineData("Day18_Input/test6.input", 23340)]
        [InlineData("Day18_Input/puzzle.input", 283582817678281)]	
        public void TestPart2Solution(string inputFile, long expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day18Solver.Part2Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
