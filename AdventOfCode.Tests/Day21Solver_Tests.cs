using Day_21_Solver;
using Xunit;
namespace AdventOfCode.Tests
{
    public class Day21Solver_Tests
    {
        [Theory]
        [InlineData("Day21_Input/test.input", 5)]
        [InlineData("Day21_Input/puzzle.input", 1885)]	
        public void TestPart1Solution(string inputFile, int expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day21Solver.Part1Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("Day21_Input/test.input", "mxmxvkd,sqjhc,fvjkl")]
        [InlineData("Day21_Input/puzzle.input", "fllssz,kgbzf,zcdcdf,pzmg,kpsdtv,fvvrc,dqbjj,qpxhfp")]
        public void TestPart2Solution(string inputFile, string expected)
        {
            // Arrange
            string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

            // Act
            var result = Day21Solver.Part2Solution(lines);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
