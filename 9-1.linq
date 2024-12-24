<Query Kind="Program">
  <NuGetReference>BenchmarkDotNet</NuGetReference>
  <Namespace>BenchmarkDotNet.Attributes</Namespace>
  <Namespace>BenchmarkDotNet.Configs</Namespace>
  <Namespace>BenchmarkDotNet.Running</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

void Main()
{
	var blocksLengths = new List<int>();
	long arrayLength = 0;
	foreach (string line in File.ReadLines("C:/Users/wmoore/Documents/LINQPad Queries/inputs/9.txt"))
	{
		foreach (char c in line) {
			var x = (int)Char.GetNumericValue(c);
			arrayLength += x;
			blocksLengths.Add(x);
		}
	}
	//blocksLengths.Dump();
	var files = new int?[arrayLength];
	bool isFile = true;
	var ptr = 0;
	var fileId = 0;
	foreach (var length in blocksLengths) { 
		if (isFile) {
			for (int i = 0; i < length; i++) {
				files[ptr] = fileId;
				ptr++;
			}
			fileId++;
		}
		else {
			for (int i = 0; i < length; i++) {
				files[ptr] = null;
				ptr++;
			}
		}
		isFile = !isFile;
	}
	//files.Dump();
	bool exit = false;
	var ptr1 = files.Length - 1; // points to where we are currently looking at from the end for files to move
	var ptr2 = 0; // points to current earliest empty spot in files
	while (!exit) {
		int? value = null;
		for (int i = ptr1; i > ptr2; i--) {
			if (files[i] != null) {
				value = files[i];
				files[i] = null;
				ptr1--;
				break;
			}
			else {
				ptr1--;
			}
		}
		if (value != null) {
			for (int i = ptr2; i < ptr1; i++) {
				if (files[i] == null) {
					files[i] = value;
					ptr2++;
					break;
				}
				else {
					ptr2++;
				}
			}
		}
		if (ptr1 <= ptr2) exit = true;
	}
	//files.Dump();
	// get checksum
	long checksum = 0;
	for (int i = 0; i <= ptr1; i++) {
		checksum += (files[i] ?? 0) * i;
	}
	checksum.Dump();
}

// You can define other methods, fields, classes and namespaces here