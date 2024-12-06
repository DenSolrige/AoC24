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
		bool reportValid = false;
		// No cute solution here, the input is small so brute force all options
		for (int j = 0; j < report.Count; j++) {
			bool isValueAscending = report[0] - report[1] < 0;
			if (j == 0) { isValueAscending = report[1] - report[2] < 0; }
			if (j == 1) { isValueAscending = report[0] - report[2] < 0; }
			bool skippedReportValid = true;
			for (int i = 0; i < report.Count - 1; i++) {
				// Skip comparing j -> j + 1 and j - 1 -> j
				if (i == j || (i == j - 1 && i == report.Count - 2)) { continue; }
				int lower = i;
				int upper = i == j - 1 ? i + 2 : i + 1;
				//("lower: " + report[lower] + " upper: " + report[upper]).Dump();
				if (report[lower] - report[upper] < 0 != isValueAscending
					|| report[lower] == report[upper]
					|| Math.Abs(report[lower] - report[upper]) > 3) 
				{
					skippedReportValid = false;
					break;
				}
			}
			// found a passing skip, exit
			if (skippedReportValid) { 
				//"passed".Dump(); 
				reportValid = true; 
				break; 
			}
		}
		if (reportValid) { numPassing++; }
		//else { "failed".Dump(); }
	});
	
	numPassing.Dump();
}

// You can define other methods, fields, classes and namespaces here