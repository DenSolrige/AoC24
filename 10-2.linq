<Query Kind="Program">
  <NuGetReference>BenchmarkDotNet</NuGetReference>
  <Namespace>BenchmarkDotNet.Attributes</Namespace>
  <Namespace>BenchmarkDotNet.Configs</Namespace>
  <Namespace>BenchmarkDotNet.Running</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

void Main()
{
	var map = new List<List<int>>();
	foreach (string line in File.ReadLines("C:/Users/wmoore/Documents/LINQPad Queries/inputs/10.txt"))
	{
		map.Add(line.Select(x => (int)Char.GetNumericValue(x)).ToList());
	}
	//map.Dump();
	// find starting locations
	var startingLocations = new List<(int x,int y)>();
	int y = 0;
	foreach (var line in map) {
		int x = 0;
		foreach (var val in line) {
			if (val == 0) {
				startingLocations.Add((x,y));
			}
			x++;
		}
		y++;
	}
	//startingLocations.Dump();
	var exit = false;
	var pastLocations = startingLocations;
	var height = 0;
	while (!exit) {
		//height.Dump();
		//pastLocations.Dump();
		var nextLocations = new List<(int x,int y)>();
		foreach (var location in pastLocations) {
			// check left
			if (location.x > 0 && map[location.y][location.x-1] == height + 1) {
				nextLocations.Add((location.x-1, location.y));
			}
			// check right
			if (location.x < map[0].Count - 1 && map[location.y][location.x+1] == height + 1) {
				nextLocations.Add((location.x+1, location.y));
			}
			// check up
			if (location.y > 0 && map[location.y-1][location.x] == height + 1) {
				nextLocations.Add((location.x, location.y-1));
			}
			// check down
			if (location.y < map.Count - 1 && map[location.y+1][location.x] == height + 1) {
				nextLocations.Add((location.x, location.y+1));
			}
			//nextLocations.Dump();
		}
		pastLocations = nextLocations;
		height++;
		if (height == 9) exit = true;
	}
	pastLocations.Count.Dump();
}

// You can define other methods, fields, classes and namespaces here