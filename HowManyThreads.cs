
using System;
using System.Threading;

// This code shows how many threads can be
// created simultaneously in one process
// I added Console.ReadLine so that threads block
// System runs out of memory after a while

class HowManyThreadsTest {
	private static int _count;
	
	public static void Main(string[] args) {
		while (true) {
			try {
				var t = new Thread(() => {
					Console.WriteLine($"Thread No : { _count++ } is created.");
					Console.ReadLine();
				});
			
				t.Start();
			}
			catch (OutOfMemoryException) {
				Console.WriteLine($"System ran out of memory after { _count } threads.");
			}
		}
	}
}
