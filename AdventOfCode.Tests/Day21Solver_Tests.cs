using Day_21_Solver;
using Xunit;
namespace AdventOfCode.Tests
{
   public class Day21Solver_Tests
   {
		//[Theory]
		//[InlineData("Day21_Input/test.input", 34241)]
		//[InlineData("Day21_Input/puzzle.input", 3429947)]	
       public void TestPart1Solution(string inputFile, int expected)
       {
			// Arrange
			string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

			// Act
			var result = Day21Solver.Part1Solution(lines);

			// Assert
			Assert.Equal(expected, result);
       }

		//[Theory]
		//[InlineData("Day21_Input/test.input", 51316)]
	//[InlineData("Day21_Input/puzzle.input", 5142043)]
       public void TestPart2Solution(string inputFile, int expected)
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
