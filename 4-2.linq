<Query Kind="Program">
  <NuGetReference>BenchmarkDotNet</NuGetReference>
  <Namespace>BenchmarkDotNet.Attributes</Namespace>
  <Namespace>BenchmarkDotNet.Configs</Namespace>
  <Namespace>BenchmarkDotNet.Running</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

void Main()
{
	var gridLines = new List<string>();
	var xmasCount = 0;
	foreach (string line in File.ReadLines("C:/Users/wmoore/Documents/LINQPad Queries/inputs/4.txt"))
	{
		gridLines.Add(line);
	}
	//gridLines.Dump();
	for (int i = 1; i < gridLines.Count - 1; i++) {
		var line = gridLines[i];
		for (int j = 1; j < line.Length - 1; j++) {
			var letter = line[j];
			var m1 = gridLines[i-1][j-1] == 'M';
			var s1 = gridLines[i-1][j-1] == 'S';
			var m2 = gridLines[i+1][j+1] == 'M';
			var s2 = gridLines[i+1][j+1] == 'S';
			var m3 = gridLines[i-1][j+1] == 'M';
			var s3 = gridLines[i-1][j+1] == 'S';
			var m4 = gridLines[i+1][j-1] == 'M';
			var s4 = gridLines[i+1][j-1] == 'S';
			if (letter == 'A' && (m1 && s2 || s1 && m2) && (m3 && s4 || s3 && m4)) {
				xmasCount++;
			}
		}
	}
	xmasCount.Dump();
}
