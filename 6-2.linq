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
	// Obstacles the guard hit along with the direction they were going when hitting the obstacle
	var obstacles = new HashSet<(int,int,int)>();
	// Up = 0,
	// Right = 1
	// Down = 2
	// Left = 3
	var direction = 0;
	
	while (!exit) {
		// move guard
		switch (direction) {
			case 0: { 
				guard = (guard.x, guard.y-1); 
				if (guard.y <= 0) { exit = true; } 
				else if (gridLines[guard.y-1][guard.x] == '#') { obstacles.Add((guard.x, guard.y-1,direction)); direction = (direction+1)%4;  }
				break; 
			}
			case 1: { 
				guard = (guard.x+1, guard.y); 
				if (guard.x >= width - 1) { exit = true; } 
				else if (gridLines[guard.y][guard.x+1] == '#') { obstacles.Add((guard.x+1, guard.y,direction)); direction = (direction+1)%4; }
				break;
			}
			case 2: { 
				guard = (guard.x, guard.y+1); 
				if (guard.y >= height - 1) { exit = true; } 
				else if (gridLines[guard.y+1][guard.x] == '#') { obstacles.Add((guard.x, guard.y+1,direction)); direction = (direction+1)%4;  }
				break; 
			}
			case 3: { 
				guard = (guard.x-1, guard.y); 
				if (guard.x <= 0) { exit = true; } 
				else if (gridLines[guard.y][guard.x-1] == '#') { obstacles.Add((guard.x-1, guard.y,direction)); direction = (direction+1)%4;  }
				break; 
			}
		}
	}
	// Now have the obstacles the guard collides with
	// obstacles.Dump();
	
	// Filter them down to only ones where we can exploit them 
	// This is all obstacles where the following:
	// 1. you can go the opposite direction from the one the guard was going when they hit the obstacle
	// 2. When going that new direction you encounter one (OR MORE) obstacles to your right BEFORE hitting an obstacle in front of you
	// 3. You then go to each of the obstacles that was to your right and turn left when you are next to them and repeat the logic for step 2.
	// 4. Repeat the logic for step 3. again and finally check that while walking away from the last obstacle you walk past the original obstacle 
	// 5. Each step you walk past without an obstacle at your right could be where we place a new obstacle (just one though) 
	// somewhat ^ flawed needs a little cleaning up
}

// You can define other methods, fields, classes and namespaces here