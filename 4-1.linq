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
	
	var gridNodes = new List<(double,double,char)>();
	var xmasCount = 0;
	int y = 0;
	foreach (string line in File.ReadLines("C:/Users/wmoore/Documents/LINQPad Queries/inputs/4-test.txt"))
	{
		int x = 0;
		foreach (char c in line) {
	    	gridNodes.Add((x, y, c));
			x++;
		}
		y--;
	}
	//gridNodes.Dump();
	gridNodes = Utils.RotateNodes(gridNodes);
	gridNodes.Dump();
	gridNodes = Utils.RotateNodes(gridNodes);
	gridNodes.Dump();
	gridNodes = Utils.RotateNodes(gridNodes);
	gridNodes.Dump();
	gridNodes = Utils.RotateNodes(gridNodes);
	gridNodes.Dump();
}

class Utils {
	public static List<(double,double,char)> RotateNodes(List<(double,double,char)> gridNodes) {
		return gridNodes.Select(node => {
			var x = (node.Item1 + node.Item2)/Math.Sqrt(2);
			var y = (node.Item2 - node.Item1)/Math.Sqrt(2);
			return (x, y, node.Item3);
		}).ToList();
	}
}