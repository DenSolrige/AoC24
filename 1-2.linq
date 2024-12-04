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
	var ids2 = new Dictionary<int,int>();
	foreach (string line in File.ReadLines("C:/Users/wmoore/Documents/LINQPad Queries/inputs/1.txt"))
	{
	    var lineWords = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
		ids1.Add(Int32.Parse(lineWords[0]));
		var id2 = Int32.Parse(lineWords[1]);
		if (ids2.TryGetValue(id2, out var id2Count)) {
			ids2[id2] = id2Count + 1;
		}
		else {
			ids2.Add(id2, 1);
		}
	}
	
	var sum = 0;
	ids1.ForEach(id1 => {
		if (ids2.TryGetValue(id1, out var id2Count)) {
			sum += id1 * id2Count;
		}
	});
	sum.Dump();
}

// You can define other methods, fields, classes and namespaces here