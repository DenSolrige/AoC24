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
	int y = 0;
	var antennaPositions = new Dictionary<char, List<(int x, int y)>>();
	foreach (string line in File.ReadLines("C:/Users/wmoore/Documents/LINQPad Queries/inputs/8.txt"))
	{
		int x = 0;
		foreach (char c in line) {
			if (c != '.') {
				if (antennaPositions.TryGetValue(c, out var cPositions)) {
					cPositions.Add((x,y));
				}
				else {
					antennaPositions.Add(c, new List<(int x, int y)> {(x,y)});
				}
			}
			x++;
		}
		gridLines.Add(line);
		y++;
	}
	//gridLines.Dump();
	var width = gridLines[0].Length;
	var height = gridLines.Count;
	//antennaPositions.Dump();
	var allAntiNodes = new HashSet<(int x, int y)>();
	foreach (var entry in antennaPositions) {
		var antennaCombinations = entry.Value.SelectMany((x, i) => entry.Value.Skip(i + 1), (x, y) => (a1:x, a2:y));
		foreach (var combo in antennaCombinations) {
			allAntiNodes.Add(combo.a1);
			allAntiNodes.Add(combo.a2);
			int antiX = combo.a1.x;
			int antiY = combo.a1.y;
			while (antiX >= 0 && antiX < width && antiY >= 0 && antiY < height) {
				antiX += combo.a1.x-combo.a2.x;
				antiY += combo.a1.y-combo.a2.y;
				allAntiNodes.Add((antiX,antiY));
			}
			antiX = combo.a2.x;
			antiY = combo.a2.y;
			while (antiX >= 0 && antiX < width && antiY >= 0 && antiY < height) {
				antiX += combo.a2.x-combo.a1.x;
				antiY += combo.a2.y-combo.a1.y;
				allAntiNodes.Add((antiX,antiY));
			}
		}
	}
	var antiNodes = allAntiNodes.Where(n => n.x >= 0 && n.x < width && n.y >= 0 && n.y < height).ToList();
	//antiNodes.Dump();
	antiNodes.Count.Dump();
}

// You can define other methods, fields, classes and namespaces here