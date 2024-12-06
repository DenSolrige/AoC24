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
	var enabled = true;
	foreach (string line in File.ReadLines("C:/Users/wmoore/Documents/LINQPad Queries/inputs/3.txt"))
	{
	    var matches = Regex.Matches(line, @"(do\(\))|(don't\(\))|(mul\((\d+),(\d+)\))");
		//matches.Dump();
		foreach (Match match in matches) {
			if (match.Groups[1].Success) { (match.Groups[0].Value).Dump();enabled = true; }
			else if (match.Groups[2].Success) { (match.Groups[0].Value).Dump();enabled = false; }
			else if (enabled && match.Groups[3].Success) {
				(match.Groups[0].Value).Dump();
				var val1 = Int32.Parse(match.Groups[4].Value);
				var val2 = Int32.Parse(match.Groups[5].Value);
				sum += val1 * val2;
			}
			else {
				("--"+match.Groups[0].Value+"--").Dump();
			}
		}
	}
	sum.Dump();
}

// You can define other methods, fields, classes and namespaces here