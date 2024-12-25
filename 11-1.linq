<Query Kind="Program">
  <NuGetReference>BenchmarkDotNet</NuGetReference>
  <Namespace>BenchmarkDotNet.Attributes</Namespace>
  <Namespace>BenchmarkDotNet.Configs</Namespace>
  <Namespace>BenchmarkDotNet.Running</Namespace>
  <Namespace>System.Security.Cryptography</Namespace>
</Query>

void Main()
{
	var stoneValues = new List<int>();
	foreach (string line in File.ReadLines("C:/Users/wmoore/Documents/LINQPad Queries/inputs/11.txt"))
	{
	    stoneValues = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => Int32.Parse(x)).ToList();
	}
	//stoneValues.Dump();
	
	var firstStone = new Stone(null, stoneValues[0], 25);
	var lastStone = firstStone;
	for (int i = 1; i < stoneValues.Count; i++) {
		var newStone = new Stone(null, stoneValues[i], 25);
		lastStone.after = newStone;
		lastStone = newStone;
	}

	var stone = firstStone;
	while (stone != null) {
		//stone.value.Dump();
		while (stone.remainingBlinks >= 1) {
			stone.Blink();
		}
		stone = stone.after;
	}
	
	long stoneCount = 0;
	stone = firstStone;
	while (stone != null) {
		//stone.value.Dump();
		stoneCount++;
		stone = stone.after;
	}
	stoneCount.Dump();
}

class Stone {
	public Stone? after;
	public long value;
	public int remainingBlinks;
	
	public Stone (Stone? after, long value, int remainingBlinks) {
		this.after = after;
		this.value = value;
		this.remainingBlinks = remainingBlinks;
	}
	
	public void Blink () {
		this.remainingBlinks--;
		var digits = (int)Math.Floor(Math.Log10(this.value) + 1);
		if (this.value == 0) {
			this.value = 1;
		}
		else if (digits % 2 == 0) {
			this.Split();
		}
		else {
			this.value *= 2024;
		}
	}
	
	private void Split () {
		var stringVal = this.value.ToString();
		var firstVal = long.Parse(stringVal.Substring(0, stringVal.Length / 2));
		var secondVal = long.Parse(stringVal.Substring(stringVal.Length / 2));
		this.value = firstVal;
		var newStone = new Stone(this.after, secondVal, this.remainingBlinks);
		this.after = newStone;
	}
}
// You can define other methods, fields, classes and namespaces here