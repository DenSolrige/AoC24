<Query Kind="Program">
  <NuGetReference>BenchmarkDotNet</NuGetReference>
  <Namespace>BenchmarkDotNet.Attributes</Namespace>
  <Namespace>BenchmarkDotNet.Configs</Namespace>
  <Namespace>BenchmarkDotNet.Running</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

void Main()
{
	var blocks = new List<(int index, int fileId, int?[] array)>();
	var emptySpaces = new List<(int index, int space, int?[] array)>();
	bool isFile = true;
	var fileId = 0;
	var index = 0;
	foreach (string line in File.ReadLines("C:/Users/wmoore/Documents/LINQPad Queries/inputs/9.txt"))
	{
		foreach (char c in line) {
			var x = (int)Char.GetNumericValue(c);
			var arr = new int?[x];
			if (isFile) {
				for (int i = 0; i < x; i++) {
					arr[i] = fileId;
				}
				blocks.Add((index, fileId, arr));
				fileId++;
			}
			else {
				emptySpaces.Add((index, x, arr));
			}
			index += x;
			isFile = !isFile;
		}
	}
	//blocks.Dump();
	//emptySpaces.Dump();
	for (int i = blocks.Count - 1; i >= 0; i--) {
		var block = blocks[i];
		// find empty block with enough space
		for (int k = 0; k < emptySpaces.Count; k++) {
			var emptySpace = emptySpaces[k];
			if (emptySpace.index > block.index) break;
			if (emptySpace.space >= block.array.Length) {
				// "move" values over from the array
				for (int j = 0; j < block.array.Length; j++) {
					block.array[j] = null;
				}
				int moveCount = 0;
				for (int j = 0; j < emptySpace.array.Length; j++) {
					if (emptySpace.array[j] != null) continue;
					else {
						emptySpace.array[j] = block.fileId;
						moveCount++;
						if (moveCount == block.array.Length) break;
					}
				}
				emptySpaces[k] = (emptySpace.index, emptySpace.space - block.array.Length, emptySpace.array);
				break;
			}
		}
	}
	//blocks.Dump();
	//emptySpaces.Dump();
	long checksum = 0;
	foreach (var block in blocks) {
		for (int i = 0; i < block.array.Length; i++) {
			checksum += (block.array[i] ?? 0) * (block.index + i);
		}
	}
	foreach (var block in emptySpaces) {
		for (int i = 0; i < block.array.Length; i++) {
			checksum += (block.array[i] ?? 0) * (block.index + i);
		}
	}
	checksum.Dump();
}
