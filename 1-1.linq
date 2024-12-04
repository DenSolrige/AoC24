<Query Kind="Program">
  <NuGetReference>BenchmarkDotNet</NuGetReference>
  <Namespace>BenchmarkDotNet.Attributes</Namespace>
  <Namespace>BenchmarkDotNet.Configs</Namespace>
  <Namespace>BenchmarkDotNet.Running</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

void Main()
{
	var ids1 = new List<int>();
	var ids2 = new List<int>();
	foreach (string line in File.ReadLines("C:/Users/wmoore/Documents/LINQPad Queries/inputs/1.txt"))
	{
	    var lineWords = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
		ids1.Add(Int32.Parse(lineWords[0]));
		ids2.Add(Int32.Parse(lineWords[1]));
	}
	ids1.Sort();
	ids2.Sort();
	
	var sum = 0;
	for (var i = 0; i < ids1.Count; i++) {
		var diff = ids1[i] - ids2[i];
		diff = Math.Abs(diff);
		sum += diff;
	}
	sum.Dump();
}

// You can define other methods, fields, classes and namespaces here