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
	var guardOrginalPosition = (x:0,y:0);
	foreach (string line in File.ReadLines("C:/Users/wmoore/Documents/LINQPad Queries/inputs/6.txt"))
	{
		gridLines.Add(line);
		var guardIndex = line.IndexOf('^');
		if (guardIndex != -1) guardOrginalPosition = (guardIndex, height);
		height++;
	}
	//gridLines.Dump();
	var guard = guardOrginalPosition;
	bool exit = false;
	var width = gridLines[0].Length;
	//height.Dump();
	//width.Dump();
	var traversedSpots = new HashSet<(int x,int y)>();
	// Up = 0,
	// Right = 1
	// Down = 2
	// Left = 3
	var direction = 0;
	
	while (!exit) {
		// move guard
		switch (direction) {
			case 0: { 
				if (guard.y <= 0) { exit = true; traversedSpots.Add(guard); } 
				else if (gridLines[guard.y-1][guard.x] == '#') direction = (direction + 1) % 4;
				else guard = (guard.x, guard.y - 1); 
				break; 
			}
			case 1: { 
				if (guard.x >= width - 1) { exit = true; traversedSpots.Add(guard); } 
				else if (gridLines[guard.y][guard.x+1] == '#') direction = (direction + 1) % 4;
				else guard = (guard.x + 1, guard.y); 
				break;
			}
			case 2: { 
				if (guard.y >= height - 1) { exit = true; traversedSpots.Add(guard); } 
				else if (gridLines[guard.y+1][guard.x] == '#') direction = (direction + 1) % 4;
				else guard = (guard.x, guard.y + 1); 
				break; 
			}
			case 3: { 
				if (guard.x <= 0) { exit = true; traversedSpots.Add(guard); } 
				else if (gridLines[guard.y][guard.x-1] == '#') direction = (direction + 1) % 4;
				else guard = (guard.x - 1, guard.y); 
				break; 
			}
		}
		// add guard position to set 
		traversedSpots.Add(guard);
	}
	traversedSpots.Remove(guardOrginalPosition);
	//traversedSpots.Dump();
	var loopingCount = 0;
	// There's a good chance that some cleanup can be done on these spots to remove values that would never result in a loop
	foreach (var spot in traversedSpots) {
		var newLine = gridLines[spot.y].ToCharArray();
		newLine[spot.x] = '#';
		gridLines[spot.y] = new string(newLine);
		//gridLines.Dump();
		var newTraversedSpots = new HashSet<(int,int,int)>();
		exit = false;
		guard = guardOrginalPosition;
		direction = 0;
		var looped = false;
		while (!exit) {
			newTraversedSpots.Add((guard.x,guard.y,direction));
			// move guard
			switch (direction) {
				case 0: { 
					if (guard.y <= 0) { exit = true; } 
					else if (gridLines[guard.y-1][guard.x] == '#') direction = (direction + 1) % 4;
					else guard = (guard.x, guard.y - 1); 
					break; 
				}
				case 1: { 
					if (guard.x >= width - 1) { exit = true; } 
					else if (gridLines[guard.y][guard.x+1] == '#') direction = (direction + 1) % 4;
					else guard = (guard.x + 1, guard.y); 
					break;
				}
				case 2: { 
					if (guard.y >= height - 1) { exit = true; } 
					else if (gridLines[guard.y+1][guard.x] == '#') direction = (direction + 1) % 4;
					else guard = (guard.x, guard.y + 1); 
					break; 
				}
				case 3: { 
					if (guard.x <= 0) { exit = true; } 
					else if (gridLines[guard.y][guard.x-1] == '#') direction = (direction + 1) % 4;
					else guard = (guard.x - 1, guard.y); 
					break; 
				}
			}
			//(guard.x,guard.y,direction).Dump();

			if (!exit && newTraversedSpots.Contains((guard.x,guard.y,direction))) {
				//newTraversedSpots.Dump();
				//"exitting".Dump();
				loopingCount++;
				looped = true;
				exit = true;
			}
		}
		if (looped) {
			//newTraversedSpots.Dump();
			//gridLines.Dump();
		}
		else {
			//gridLines.Dump();
		}
		
		var oldLine = gridLines[spot.y].ToCharArray();
		oldLine[spot.x] = '.';
		gridLines[spot.y] = new string(oldLine);
		//gridLines.Dump();
	}
	loopingCount.Dump();
}

// You can define other methods, fields, classes and namespaces here