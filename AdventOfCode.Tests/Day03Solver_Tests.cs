using Day_03_Solver;
using Xunit;
namespace AdventOfCode.Tests
{
   public class Day03Solver_Tests
   {
		//[Theory]
		//[InlineData("Day03_Input/test.input", 34241)]
		//[InlineData("Day03_Input/puzzle.input", 3429947)]	
       public void TestPart1Solution(string inputFile, int expected)
       {
			// Arrange
			string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

			// Act
			var result = Day03Solver.Part1Solution(lines);

			// Assert
			Assert.Equal(expected, result);
       }

		//[Theory]
		//[InlineData("Day03_Input/test.input", 51316)]
	//[InlineData("Day03_Input/puzzle.input", 5142043)]
       public void TestPart2Solution(string inputFile, int expected)
       {
			// Arrange
			string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

			// Act
			var result = Day03Solver.Part2Solution(lines);

			// Assert
			Assert.Equal(expected, result);
       }
   }
}
