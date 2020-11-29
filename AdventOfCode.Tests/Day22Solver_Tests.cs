using Day_22_Solver;
using Xunit;
namespace AdventOfCode.Tests
{
   public class Day22Solver_Tests
   {
		//[Theory]
		//[InlineData("Day22_Input/test.input", 34241)]
		//[InlineData("Day22_Input/puzzle.input", 3429947)]	
       public void TestPart1Solution(string inputFile, int expected)
       {
			// Arrange
			string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}");

			// Act
			var result = Day22Solver.Part1Solution(lines);

			// Assert
			Assert.Equal(expected, result);
       }

		//[Theory]
		//[InlineData("Day22_Input/test.input", 51316)]
	//[InlineData("Day22_Input/puzzle.input", 5142043)]
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
