using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using nqueens.lib;

namespace knuther
{
  class Program
  {
    static void Main(string[] args)
    {
      IList<int> theList = new int[] { 1, 6, 1, 4, 2, 7, 0, 1, 6, 0, 0 };
      // IList<int> theList = new int[] { 0, 3, 5, 6, 7, 8, 9 };
      var permutations = MathNet.Numerics.Combinatorics.Permutations(theList.Count());

      Console.WriteLine($"There are {permutations} permutations to calculate.");
      Console.ReadLine();

      var counter = 1;
      theList = theList.OrderBy(i => i).ToList();
      do
      {
        Console.WriteLine($"{counter++,7}: {string.Join(",", theList)}");
        theList = KnuthsPermutationsCalculator<int>.GetNextPermutation(theList);
      }
      while (theList != null);

      Console.WriteLine("DONE!");
    }
  }
}
