<Query Kind="Program">
  <NuGetReference>BenchmarkDotNet</NuGetReference>
  <Namespace>BenchmarkDotNet.Attributes</Namespace>
  <Namespace>BenchmarkDotNet.Configs</Namespace>
  <Namespace>BenchmarkDotNet.Running</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

void Main()
{
	var equations = new List<(long testValue, List<int> operands)>();
	foreach (string line in File.ReadLines("C:/Users/wmoore/Documents/LINQPad Queries/inputs/7.txt"))
	{
	    var testValue = long.Parse(line.Split(':', StringSplitOptions.RemoveEmptyEntries)[0]);
		var operands = line.Split(':', StringSplitOptions.RemoveEmptyEntries)[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => Int32.Parse(x)).ToList();
		equations.Add((testValue, operands));
	}
	long sum = 0;
	//equations.Dump();

	foreach (var equation in equations) {
		for (int i = 0; i < Math.Pow(3, (equation.operands.Count - 1)); i++) {
			long testSum = equation.operands[0];
			var equationString = ""+testSum;
			for (int j = 0; j < equation.operands.Count - 1; j++) {
				long operatorValue = (long)(i/Math.Pow(3,j)) % 3; // 0 -> +, 1 -> *, 2 -> |
				switch (operatorValue) {
					case 0: {
						testSum = testSum + equation.operands[j+1];
						equationString += '+';
						break;
					}
					case 1: {
						testSum = testSum * equation.operands[j+1];
						equationString += '*';
						break;
					}
					case 2: {
						testSum = long.Parse(testSum.ToString() + equation.operands[j+1].ToString());
						equationString += '|';
						break;
					}
				}
				equationString += equation.operands[j+1];
			}
			if (testSum == equation.testValue) {
				sum += equation.testValue;
				//(equationString+" = "+equation.testValue+" - Match!").Dump();
				break;
			}
			else {
				//(equationString+" = "+testSum+" != "+equation.testValue+" - No Match").Dump();
			}
		}
	}
	sum.Dump();
}
