<Query Kind="Program">
  <NuGetReference>BenchmarkDotNet</NuGetReference>
  <Namespace>BenchmarkDotNet.Attributes</Namespace>
  <Namespace>BenchmarkDotNet.Configs</Namespace>
  <Namespace>BenchmarkDotNet.Running</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

void Main()
{
	var sum = 0;
	foreach (string line in File.ReadLines("C:/Users/wmoore/Documents/LINQPad Queries/inputs/3.txt"))
	{
	    var matches = Regex.Matches(line, @"mul\((\d+),(\d+)\)");
		//matches.Dump();
		foreach (Match match in matches) {
			var val1 = Int32.Parse(match.Groups[1].Value);
			var val2 = Int32.Parse(match.Groups[2].Value);
			sum += val1 * val2;
		}
	}
	sum.Dump();
}

// You can define other methods, fields, classes and namespaces here