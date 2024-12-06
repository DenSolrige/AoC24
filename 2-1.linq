<Query Kind="Program">
  <NuGetReference>BenchmarkDotNet</NuGetReference>
  <Namespace>BenchmarkDotNet.Attributes</Namespace>
  <Namespace>BenchmarkDotNet.Configs</Namespace>
  <Namespace>BenchmarkDotNet.Running</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

void Main()
{
	var reports = new List<List<int>>();
	foreach (string line in File.ReadLines("C:/Users/wmoore/Documents/LINQPad Queries/inputs/2.txt"))
	{
	    var report = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => Int32.Parse(x)).ToList();
		reports.Add(report);
	}
	
	var numPassing = 0;
	//reports.Dump();
	reports.ForEach(report => {
		bool reportValid = true;
		bool isValueAscending = report[0] - report[1] < 0;
		for (int i = 0; i < report.Count - 1; i++) {
			if (report[i] - report[i+1] < 0 != isValueAscending
				|| report[i] == report[i+1]
				|| Math.Abs(report[i] - report[i+1]) > 3) 
			{
				reportValid = false;
				break;
			}

		}
		
		if (reportValid) { numPassing++; }
	});
	
	numPassing.Dump();
}


// You can define other methods, fields, classes and namespaces here