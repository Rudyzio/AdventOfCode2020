@ECHO OFF
:: Batch file to create advent of code project structure
mkdir "AdventOfCode2020"
cd AdventOfCode2020

dotnet new sln -n "AdventOfCode2020"

dotnet new classlib -o "Day 01 Solver"
dotnet new classlib -o "Day 02 Solver"
dotnet new classlib -o "Day 03 Solver"
dotnet new classlib -o "Day 04 Solver"
dotnet new classlib -o "Day 05 Solver"
dotnet new classlib -o "Day 06 Solver"
dotnet new classlib -o "Day 07 Solver"
dotnet new classlib -o "Day 08 Solver"
dotnet new classlib -o "Day 09 Solver"
dotnet new classlib -o "Day 10 Solver"
dotnet new classlib -o "Day 11 Solver"
dotnet new classlib -o "Day 12 Solver"
dotnet new classlib -o "Day 13 Solver"
dotnet new classlib -o "Day 14 Solver"
dotnet new classlib -o "Day 15 Solver"
dotnet new classlib -o "Day 16 Solver"
dotnet new classlib -o "Day 17 Solver"
dotnet new classlib -o "Day 18 Solver"
dotnet new classlib -o "Day 19 Solver"
dotnet new classlib -o "Day 20 Solver"
dotnet new classlib -o "Day 21 Solver"
dotnet new classlib -o "Day 22 Solver"
dotnet new classlib -o "Day 23 Solver"
dotnet new classlib -o "Day 24 Solver"
dotnet new classlib -o "Day 25 Solver"

dotnet sln AdventOfCode2020.sln add ".\Day 01 Solver\Day 01 Solver.csproj"
dotnet sln AdventOfCode2020.sln add ".\Day 02 Solver\Day 02 Solver.csproj"
dotnet sln AdventOfCode2020.sln add ".\Day 03 Solver\Day 03 Solver.csproj"
dotnet sln AdventOfCode2020.sln add ".\Day 04 Solver\Day 04 Solver.csproj"
dotnet sln AdventOfCode2020.sln add ".\Day 05 Solver\Day 05 Solver.csproj"
dotnet sln AdventOfCode2020.sln add ".\Day 06 Solver\Day 06 Solver.csproj"
dotnet sln AdventOfCode2020.sln add ".\Day 07 Solver\Day 07 Solver.csproj"
dotnet sln AdventOfCode2020.sln add ".\Day 08 Solver\Day 08 Solver.csproj"
dotnet sln AdventOfCode2020.sln add ".\Day 09 Solver\Day 09 Solver.csproj"
dotnet sln AdventOfCode2020.sln add ".\Day 10 Solver\Day 10 Solver.csproj"
dotnet sln AdventOfCode2020.sln add ".\Day 11 Solver\Day 11 Solver.csproj"
dotnet sln AdventOfCode2020.sln add ".\Day 12 Solver\Day 12 Solver.csproj"
dotnet sln AdventOfCode2020.sln add ".\Day 13 Solver\Day 13 Solver.csproj"
dotnet sln AdventOfCode2020.sln add ".\Day 14 Solver\Day 14 Solver.csproj"
dotnet sln AdventOfCode2020.sln add ".\Day 15 Solver\Day 15 Solver.csproj"
dotnet sln AdventOfCode2020.sln add ".\Day 16 Solver\Day 16 Solver.csproj"
dotnet sln AdventOfCode2020.sln add ".\Day 17 Solver\Day 17 Solver.csproj"
dotnet sln AdventOfCode2020.sln add ".\Day 18 Solver\Day 18 Solver.csproj"
dotnet sln AdventOfCode2020.sln add ".\Day 19 Solver\Day 19 Solver.csproj"
dotnet sln AdventOfCode2020.sln add ".\Day 20 Solver\Day 20 Solver.csproj"
dotnet sln AdventOfCode2020.sln add ".\Day 21 Solver\Day 21 Solver.csproj"
dotnet sln AdventOfCode2020.sln add ".\Day 22 Solver\Day 22 Solver.csproj"
dotnet sln AdventOfCode2020.sln add ".\Day 23 Solver\Day 23 Solver.csproj"
dotnet sln AdventOfCode2020.sln add ".\Day 24 Solver\Day 24 Solver.csproj"
dotnet sln AdventOfCode2020.sln add ".\Day 25 Solver\Day 25 Solver.csproj"

dotnet new xunit -o "AdventOfCode.Tests"
dotnet sln AdventOfCode2020.sln add ".\AdventOfCode.Tests\AdventOfCode.Tests.csproj"

dotnet add "AdventOfCode.Tests\AdventOfCode.Tests.csproj" reference ".\Day 01 Solver\Day 01 Solver.csproj"
dotnet add "AdventOfCode.Tests\AdventOfCode.Tests.csproj" reference ".\Day 02 Solver\Day 02 Solver.csproj"
dotnet add "AdventOfCode.Tests\AdventOfCode.Tests.csproj" reference ".\Day 03 Solver\Day 03 Solver.csproj"
dotnet add "AdventOfCode.Tests\AdventOfCode.Tests.csproj" reference ".\Day 04 Solver\Day 04 Solver.csproj"
dotnet add "AdventOfCode.Tests\AdventOfCode.Tests.csproj" reference ".\Day 05 Solver\Day 05 Solver.csproj"
dotnet add "AdventOfCode.Tests\AdventOfCode.Tests.csproj" reference ".\Day 06 Solver\Day 06 Solver.csproj"
dotnet add "AdventOfCode.Tests\AdventOfCode.Tests.csproj" reference ".\Day 07 Solver\Day 07 Solver.csproj"
dotnet add "AdventOfCode.Tests\AdventOfCode.Tests.csproj" reference ".\Day 08 Solver\Day 08 Solver.csproj"
dotnet add "AdventOfCode.Tests\AdventOfCode.Tests.csproj" reference ".\Day 09 Solver\Day 09 Solver.csproj"
dotnet add "AdventOfCode.Tests\AdventOfCode.Tests.csproj" reference ".\Day 10 Solver\Day 10 Solver.csproj"
dotnet add "AdventOfCode.Tests\AdventOfCode.Tests.csproj" reference ".\Day 11 Solver\Day 11 Solver.csproj"
dotnet add "AdventOfCode.Tests\AdventOfCode.Tests.csproj" reference ".\Day 12 Solver\Day 12 Solver.csproj"
dotnet add "AdventOfCode.Tests\AdventOfCode.Tests.csproj" reference ".\Day 13 Solver\Day 13 Solver.csproj"
dotnet add "AdventOfCode.Tests\AdventOfCode.Tests.csproj" reference ".\Day 14 Solver\Day 14 Solver.csproj"
dotnet add "AdventOfCode.Tests\AdventOfCode.Tests.csproj" reference ".\Day 15 Solver\Day 15 Solver.csproj"
dotnet add "AdventOfCode.Tests\AdventOfCode.Tests.csproj" reference ".\Day 16 Solver\Day 16 Solver.csproj"
dotnet add "AdventOfCode.Tests\AdventOfCode.Tests.csproj" reference ".\Day 17 Solver\Day 17 Solver.csproj"
dotnet add "AdventOfCode.Tests\AdventOfCode.Tests.csproj" reference ".\Day 18 Solver\Day 18 Solver.csproj"
dotnet add "AdventOfCode.Tests\AdventOfCode.Tests.csproj" reference ".\Day 19 Solver\Day 19 Solver.csproj"
dotnet add "AdventOfCode.Tests\AdventOfCode.Tests.csproj" reference ".\Day 20 Solver\Day 20 Solver.csproj"
dotnet add "AdventOfCode.Tests\AdventOfCode.Tests.csproj" reference ".\Day 21 Solver\Day 21 Solver.csproj"
dotnet add "AdventOfCode.Tests\AdventOfCode.Tests.csproj" reference ".\Day 22 Solver\Day 22 Solver.csproj"
dotnet add "AdventOfCode.Tests\AdventOfCode.Tests.csproj" reference ".\Day 23 Solver\Day 23 Solver.csproj"
dotnet add "AdventOfCode.Tests\AdventOfCode.Tests.csproj" reference ".\Day 24 Solver\Day 24 Solver.csproj"
dotnet add "AdventOfCode.Tests\AdventOfCode.Tests.csproj" reference ".\Day 25 Solver\Day 25 Solver.csproj"

cd "AdventOfCode.Tests"

mkdir "Day01_Input"
mkdir "Day02_Input"
mkdir "Day03_Input"
mkdir "Day04_Input"
mkdir "Day05_Input"
mkdir "Day06_Input"
mkdir "Day07_Input"
mkdir "Day08_Input"
mkdir "Day09_Input"
mkdir "Day10_Input"
mkdir "Day11_Input"
mkdir "Day12_Input"
mkdir "Day13_Input"
mkdir "Day14_Input"
mkdir "Day15_Input"
mkdir "Day16_Input"
mkdir "Day17_Input"
mkdir "Day18_Input"
mkdir "Day19_Input"
mkdir "Day20_Input"
mkdir "Day21_Input"
mkdir "Day22_Input"
mkdir "Day23_Input"
mkdir "Day24_Input"
mkdir "Day25_Input"

rm UnitTest1.cs

FOR /L %%A IN (1,1,9) DO (
  	(
		echo using Day_0%%A_Solver;
		echo using Xunit;

		echo namespace AdventOfCode.Tests
		echo {
		echo    public class Day0%%ASolver_Tests
		echo    {
		echo 		//[Theory]
		echo 		//[InlineData("Day0%%A_Input/test.input", 34241^)]
        echo 		//[InlineData("Day0%%A_Input/puzzle.input", 3429947^)]	
		echo        public void TestPart1Solution(string inputFile, int expected^)
		echo        {
		echo 			// Arrange
		echo 			string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}"^);
		echo.
		echo 			// Act
		echo 			var result = Day0%%ASolver.Part1Solution(lines^);
		echo.
		echo 			// Assert
		echo 			Assert.Equal(expected, result^);
		echo        }
		echo.
		echo 		//[Theory]
        echo 		//[InlineData("Day0%%A_Input/test.input", 51316^)]
        echo		//[InlineData("Day0%%A_Input/puzzle.input", 5142043^)]
		echo        public void TestPart2Solution(string inputFile, int expected^)
		echo        {
		echo 			// Arrange
		echo 			string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}"^);
		echo.
		echo 			// Act
		echo 			var result = Day0%%ASolver.Part2Solution(lines^);
		echo.
		echo 			// Assert
		echo 			Assert.Equal(expected, result^);
		echo        }
		echo    }
		echo }
	)>Day0%%ASolver_Tests.cs
)

FOR /L %%A IN (10,1,25) DO (
  	(
		echo using Day_%%A_Solver;
		echo using Xunit;

		echo namespace AdventOfCode.Tests
		echo {
		echo    public class Day%%ASolver_Tests
		echo    {
		echo 		//[Theory]
		echo 		//[InlineData("Day%%A_Input/test.input", 34241^)]
        echo 		//[InlineData("Day%%A_Input/puzzle.input", 3429947^)]	
		echo        public void TestPart1Solution(string inputFile, int expected^)
		echo        {
		echo 			// Arrange
		echo 			string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}"^);
		echo.
		echo 			// Act
		echo 			var result = Day%%ASolver.Part1Solution(lines^);
		echo.
		echo 			// Assert
		echo 			Assert.Equal(expected, result^);
		echo        }
		echo.
		echo 		//[Theory]
        echo 		//[InlineData("Day%%A_Input/test.input", 51316^)]
        echo		//[InlineData("Day%%A_Input/puzzle.input", 5142043^)]
		echo        public void TestPart2Solution(string inputFile, int expected^)
		echo        {
		echo 			// Arrange
		echo 			string[] lines = System.IO.File.ReadAllLines($"../../../{inputFile}"^);
		echo.
		echo 			// Act
		echo 			var result = Day%%ASolver.Part2Solution(lines^);
		echo.
		echo 			// Assert
		echo 			Assert.Equal(expected, result^);
		echo        }
		echo    }
		echo }
	)>Day%%ASolver_Tests.cs
)

cd ..

FOR /L %%A IN (1,1,9) DO (
	cd "Day 0%%A Solver"

  	(
	echo	namespace Day_0%%A_Solver
	echo		{
	echo	    public static class Day0%%ASolver
	echo	    {
	echo	        public static int Part1Solution(string[] lines^)
	echo	        {
	echo	            return 0;
	echo	        }
	echo.
	echo	        public static int Part2Solution(string[] lines^)
	echo	        {
	echo	            return 0;
	echo	        }
	echo	    }
	echo	}
	)>Day0%%ASolver.cs

	rm Class1.cs

	(
	echo	### [Day %%A: ](https://adventofcode.com/2020/day/%%A^)
	echo.
	echo 	## Part 1
	echo.
	echo 	## Part 2
	)>README.md

	cd ..
)

FOR /L %%A IN (10,1,25) DO (
	cd "Day %%A Solver"

  	(
	echo	namespace Day_%%A_Solver
	echo	{
	echo	    public static class Day%%ASolver
	echo	    {
	echo	        public static int Part1Solution(string[] lines^)
	echo	        {
	echo	            return 0;
	echo	        }
	echo.
	echo	        public static int Part2Solution(string[] lines^)
	echo	        {
	echo	            return 0;
	echo	        }
	echo	    }
	echo	}
	)>Day%%ASolver.cs

	rm Class1.cs

	(
	echo	### [Day %%A: ](https://adventofcode.com/2020/day/%%A^)
	echo.
	echo 	## Part 1
	echo.
	echo 	## Part 2
	)>README.md

	cd ..
)
dotnet clean

dotnet restore

dotnet build

PAUSE