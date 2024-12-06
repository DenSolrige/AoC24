<Query Kind="Program">
  <NuGetReference>BenchmarkDotNet</NuGetReference>
  <Namespace>BenchmarkDotNet.Attributes</Namespace>
  <Namespace>BenchmarkDotNet.Configs</Namespace>
  <Namespace>BenchmarkDotNet.Running</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

void Main()
{
	// the rotated coordinates of (x,y) are ((x+y)/√2,(y−x)/√2).
	// https://math.stackexchange.com/questions/383321/rotating-x-y-points-45-degrees
	
	// forget this, lets rotate this thing
	//var gridLines = new List<string>();
	//var xmasCount = 0;
	//foreach (string line in File.ReadLines("C:/Users/wmoore/Documents/LINQPad Queries/inputs/4-test.txt"))
	//{
	//    gridLines.Add(line);
	//}
	//gridLines.Dump();
	//
	//var reverseGridLines = gridLines.Select(line => new string(line.Reverse().ToArray()));
	////reverseGridLines.Dump();
	//
	//var verticalGridLines = new List<string>();
	//for (int i = 0; i < gridLines[0].Length; i++) {
	//	var verticalLine = new char[gridLines.Count];
	//	for (int j = 0; j < gridLines.Count; j++) {
	//		verticalLine[j] = gridLines[j][i];
	//	}
	//	verticalGridLines.Add(new string(verticalLine));
	//}
	////verticalGridLines.Dump();
	//
	//var reverseVerticalGridLines = verticalGridLines.Select(line => new string(line.Reverse().ToArray()));
	//
	//
	//var northEastGridLines = new List<string>();
	//for (int i = 0; i < gridLines.Count * 2 - 1; i++) {
	//	var diagonalLine = new char[gridLines.Count];
	//	if (i < gridLines.Count) {
	//	
	//	}
	//	else {
	//	
	//	}
	//	for (int j = 0; j < gridLines.Count; j++) {
	//		verticalLine[j] = gridLines[j][i];
	//	}
	//	verticalGridLines.Add(new string(verticalLine));
	//}
}

// You can define other methods, fields, classes and namespaces here