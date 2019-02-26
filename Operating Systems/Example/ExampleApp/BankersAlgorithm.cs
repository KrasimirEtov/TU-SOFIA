/*
 * Krasimir Etov - 51 gr, KSI 10 potok
 * banker's algorithm - C# implementation
 * */

using System;

namespace ExampleApp
{
	public class BankersAlgorithm
	{
		private int[,] need, allocated, max;
		private int[] available;
		private int processes, resources;

		public BankersAlgorithm()
		{
			this.processes = 5;
			this.resources = 3;
			this.available = new int[] { 3, 3, 2 };
			this.need = new int[this.processes, this.resources];
			this.max = new int[,]
			{
				{ 7, 5, 3 },
				{ 3, 2, 2 },
				{ 9, 0, 2 },
				{ 2, 2, 2 },
				{ 4, 3, 3 }
			};
			this.allocated = new int[,]
			{
				{ 0, 1, 0 },
				{ 2, 0, 0 },
				{ 3, 0, 2 },
				{ 2, 1, 1 },
				{ 0, 0, 2 }
			};

		}
		private void CalculateNeed()
		{
			for (int row = 0; row < processes; row++)
			{
				for (int col = 0; col < resources; col++)
				{
					need[row, col] = max[row, col] - allocated[row, col];
				}
			}
		}

		private bool IsSafe()
		{
			CalculateNeed();

			// mark all processes as unfinished
			var finish = new bool[processes];

			// store safe sequence
			var safeSequence = new int[processes];

			// make a copy of available resources
			var workResources = new int[resources];
			for (int i = 0; i < resources; i++)
			{
				workResources[i] = available[i];
			}
			// while all process are not finished
			// or system is not in safe state
			int count = 0;
			while (count < processes)
			{
				// Find a process which is not finish and 
				// whose needs can be satisfied with current 
				// work[] resources.
				bool found = false;
				for (int p = 0; p < processes; p++)
				{
					// First check if a process is finished, 
					// if no, go for next condition 
					if (!finish[p])
					{
						// Check if for all resources of 
						// current P need is less 
						// than work 
						int r;
						for (r = 0; r < resources; r++)
						{
							if (need[p, r] > workResources[r])
							{
								break;
							}
						}
						if (r == resources)
						{
							// Add the allocated resources of 
							// current P to the available/work 
							// resources i.e.free the resources 
							for (int temp = 0; temp < resources; temp++)
							{
								workResources[temp] += allocated[p, temp];
							}
							safeSequence[count++] = p;
							finish[p] = true;
							found = true;
						}
					}
				}
				if (!found)
				{
					Console.WriteLine("System is not in safe state!");
					return false;
				}
			}
			Console.WriteLine("System is in safe state.\nSafe sequence is: ");
			foreach (var item in safeSequence)
			{
				Console.Write($"P{item} ");
			}
			return true;
		}

		public static void Main(string[] args)
		{
			new BankersAlgorithm().IsSafe();
		}
	}
}