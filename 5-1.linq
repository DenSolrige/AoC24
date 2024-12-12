<Query Kind="Program">
  <NuGetReference>BenchmarkDotNet</NuGetReference>
  <Namespace>BenchmarkDotNet.Attributes</Namespace>
  <Namespace>BenchmarkDotNet.Configs</Namespace>
  <Namespace>BenchmarkDotNet.Running</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

void Main()
{
	var rules = new List<(int before,int after)>();
	var updates = new List<Dictionary<int,int>>();
	bool inRulesSection = true;
	foreach (string line in File.ReadLines("C:/Users/wmoore/Documents/LINQPad Queries/inputs/5.txt"))
	{
		if (line == "") { inRulesSection = false; continue; }
		if (inRulesSection) {
			var stringNums = line.Split("|");
			rules.Add((Int32.Parse(stringNums[0]),Int32.Parse(stringNums[1])));
		}
		else {
			var updateDictionary = new Dictionary<int,int>();
			line.Split(",").Select((x,i) => (k: Int32.Parse(x), v: i))
			.ToList().ForEach(kvpair => updateDictionary.Add(kvpair.k, kvpair.v));
			updates.Add(updateDictionary); 
		}
	}
	//rules.Dump();
	//updates.Dump();
	var sum = 0;
	foreach (var update in updates) {
		var pass = true;
		foreach (var rule in rules) {
			if(update.TryGetValue(rule.before, out var beforeIndex)) {
				if(update.TryGetValue(rule.after, out var afterIndex)) {
					if (beforeIndex > afterIndex) pass = false;
				}
			}
		}
		if (pass) {
			var middleIndex = update.Count / 2;
			sum += update.FirstOrDefault(x => x.Value == middleIndex).Key;
		}
	}
	sum.Dump();
}

// You can define other methods, fields, classes and namespaces here