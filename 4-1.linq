<Query Kind="Program">
  <NuGetReference>BenchmarkDotNet</NuGetReference>
  <Namespace>BenchmarkDotNet.Attributes</Namespace>
  <Namespace>BenchmarkDotNet.Configs</Namespace>
  <Namespace>BenchmarkDotNet.Running</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

void Main()
{
	var gridNodes = new List<char>();
	var xmasCount = 0;
	var n = 0; // side length of the square
	foreach (string line in File.ReadLines("C:/Users/wmoore/Documents/LINQPad Queries/inputs/4.txt"))
	{
		foreach (char c in line) {
	    	gridNodes.Add(c);
		}
		n++;
	}
	//gridNodes.Dump();
	xmasCount += Util.CountXmasInHorizontal(gridNodes, n).Dump();
	xmasCount += Util.CountXmasInDiagonal(gridNodes, n).Dump();
	gridNodes = Util.RotateGrid90Degrees(gridNodes, n);
	xmasCount += Util.CountXmasInHorizontal(gridNodes, n).Dump();
	xmasCount += Util.CountXmasInDiagonal(gridNodes, n).Dump();
	gridNodes = Util.RotateGrid90Degrees(gridNodes, n);
	xmasCount += Util.CountXmasInHorizontal(gridNodes, n).Dump();
	xmasCount += Util.CountXmasInDiagonal(gridNodes, n).Dump();
	gridNodes = Util.RotateGrid90Degrees(gridNodes, n);
	xmasCount += Util.CountXmasInHorizontal(gridNodes, n).Dump();
	xmasCount += Util.CountXmasInDiagonal(gridNodes, n).Dump();
	xmasCount.Dump();
}

class Util {
	public static int CountXmasInHorizontal(List<char> gridNodes, int n) {
		var xmasCount = 0;
		for (int i = 0; i < n; i++) {
			var line = new string(gridNodes.GetRange(i*n, n).ToArray());
			line.Dump();
			var matches = Regex.Matches(line, @"XMAS");
			xmasCount += matches.Count;
		}
		return xmasCount;
	}

	public static int CountXmasInDiagonal(List<char> gridNodes, int n) {
		var xmasCount = 0;
		// top half and middle of diagonal
		for (int i = 0; i <= n*(n-1); i+=n) {
			var line = "";
			for (int j = i; j >= i-(i/n)*(n-1); j-=n-1) {
				line += gridNodes[j];
			}
			//line.Dump();
			var matches = Regex.Matches(line, @"XMAS");
			xmasCount += matches.Count;
		}
		// bottom half of diagonal
		for (int i = n*(n-1)+1; i < n*n; i++) {
			var line = "";
			for (int j = i; j > i-(n*n-i)*(n-1); j-=n-1) {
				line += gridNodes[j];
			}
			//line.Dump();
			var matches = Regex.Matches(line, @"XMAS");
			xmasCount += matches.Count;
		}
		return xmasCount;
	}
	
	public static List<char> RotateGrid90Degrees(List<char> gridNodes, int n) {
		var rotatedNodes = new char[n*n];
		for (int i = 0; i < n*n; i++) {
			int col = i%n;
			int row = i/n;
			int newCol = n - row;
			int newRow = col;
			int newIndex = newCol + n*newRow - 1;
			rotatedNodes[newIndex] = gridNodes[i];
		}
		return rotatedNodes.ToList();
	}
}