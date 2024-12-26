<Query Kind="Program">
  <NuGetReference>BenchmarkDotNet</NuGetReference>
  <Namespace>BenchmarkDotNet.Attributes</Namespace>
  <Namespace>BenchmarkDotNet.Configs</Namespace>
  <Namespace>BenchmarkDotNet.Running</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

void Main()
{
	var stoneValues = new Dictionary<long,long>();
	var remainingBlinks = 75;
	foreach (string line in File.ReadLines("C:/Users/wmoore/Documents/LINQPad Queries/inputs/11.txt"))
	{
	    line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => long.Parse(x)).ToList().ForEach(val => {
				if (stoneValues.TryGetValue(val, out var count)) {
					stoneValues[val] = count + 1;
				}
				else {
					stoneValues.Add(val, 1);
				}
		});
	}
	//stoneValues.Dump();
	while(remainingBlinks >= 1) {
		var intermediateDict = new Dictionary<long,long>();
		foreach (var kvpair in stoneValues) {
			var digits = (int)Math.Floor(Math.Log10(kvpair.Key) + 1);
			if (kvpair.Key == 0) {
				var newValue = 1;
				if (intermediateDict.TryGetValue(newValue, out var count)) {
					intermediateDict[newValue] = kvpair.Value + count;
				}
				else {
					intermediateDict.Add(newValue, kvpair.Value);
				}
			}
			else if (digits % 2 == 0) {
				var stringVal = kvpair.Key.ToString();
				var firstVal = long.Parse(stringVal.Substring(0, stringVal.Length / 2));
				var secondVal = long.Parse(stringVal.Substring(stringVal.Length / 2));
				if (intermediateDict.TryGetValue(firstVal, out var count)) {
					intermediateDict[firstVal] = kvpair.Value + count;
				}
				else {
					intermediateDict.Add(firstVal, kvpair.Value);
				}
				if (intermediateDict.TryGetValue(secondVal, out var count2)) {
					intermediateDict[secondVal] = kvpair.Value + count2;
				}
				else {
					intermediateDict.Add(secondVal, kvpair.Value);
				}
			}
			else {
				var newValue = kvpair.Key * 2024;
				if (intermediateDict.TryGetValue(newValue, out var count)) {
					intermediateDict[newValue] = kvpair.Value + count;
				}
				else {
					intermediateDict.Add(newValue, kvpair.Value);
				}
			}
		}
		stoneValues = intermediateDict;
		remainingBlinks--;
	}
	long totalCount = 0;
	foreach (var kvpair in stoneValues) {
		totalCount += kvpair.Value;
	}
	totalCount.Dump();
}

// You can define other methods, fields, classes and namespaces here