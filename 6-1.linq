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
	var height = 0;
	var guard = (x:0,y:0);
	foreach (string line in File.ReadLines("C:/Users/wmoore/Documents/LINQPad Queries/inputs/6.txt"))
	{
		gridLines.Add(line);
		var guardIndex = line.IndexOf('^');
		if (guardIndex != -1) guard = (guardIndex, height);
		height++;
	}
	gridLines.Dump();
	bool exit = false;
	var width = gridLines[0].Length;
	var traversedSpots = new HashSet<(int,int)>();
	// Up = 0,
	// Right = 1
	// Down = 2
	// Left = 3
	var direction = 0;
	
	while (!exit) {
		// add guard position to set 
		traversedSpots.Add(guard);
		// move guard
		switch (direction) {
			case 0: { 
				guard = (guard.x, guard.y - 1); 
				if (guard.y <= 0) { exit = true; traversedSpots.Add(guard); } 
				else if (gridLines[guard.y-1][guard.x] == '#') direction = (direction + 1) % 4;
				break; 
			}
			case 1: { 
				guard = (guard.x + 1, guard.y); 
				if (guard.x >= width - 1) { exit = true; traversedSpots.Add(guard); } 
				else if (gridLines[guard.y][guard.x+1] == '#') direction = (direction + 1) % 4;
				break;
			}
			case 2: { 
				guard = (guard.x, guard.y + 1); 
				if (guard.y >= height - 1) { exit = true; traversedSpots.Add(guard); } 
				else if (gridLines[guard.y+1][guard.x] == '#') direction = (direction + 1) % 4;
				break; 
			}
			case 3: { 
				guard = (guard.x - 1, guard.y); 
				if (guard.x <= 0) { exit = true; traversedSpots.Add(guard); } 
				else if (gridLines[guard.y][guard.x-1] == '#') direction = (direction + 1) % 4;
				break; 
			}
		}
	}
	traversedSpots.Count.Dump();
}

// You can define other methods, fields, classes and namespaces here