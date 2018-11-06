using System.Collections.Generic;
using Xunit;

namespace nqueens.lib.tests {
  public class KnuthsPermutationsCalculatorTests {
    [Fact]
    public void ItGetsThePermutations () {
      var first = new int[] { 0, 1, 2 };

      var result = KnuthsPermutationsCalculator<int>.GetNextPermutation (first);
      Assert.Equal (new List<int> { 0, 2, 1 }, result);

      result = KnuthsPermutationsCalculator<int>.GetNextPermutation (result);
      Assert.Equal (new List<int> { 1, 0, 2 }, result);

      result = KnuthsPermutationsCalculator<int>.GetNextPermutation (result);
      Assert.Equal (new List<int> { 1, 2, 0 }, result);

      result = KnuthsPermutationsCalculator<int>.GetNextPermutation (result);
      Assert.Equal (new List<int> { 2, 0, 1 }, result);

      result = KnuthsPermutationsCalculator<int>.GetNextPermutation (result);
      Assert.Equal (new List<int> { 2, 1, 0 }, result);

      result = KnuthsPermutationsCalculator<int>.GetNextPermutation (result);
      Assert.Null (result);
    }

    [Fact]
    public void ItFindsTheCorrectAmountOfPermutations () {
      const int N = 8;
      var totalPermutations = MathNet.Numerics.Combinatorics.Permutations (N);
      IList<int> result = new int[N] { 0, 1, 2, 3, 4, 5, 6, 7 };

      Assert.True (totalPermutations > 0, $"Total Permutations To Calculate: {totalPermutations}");

      var numExecute = 0;
      while (result != null) {
        result = KnuthsPermutationsCalculator<int>.GetNextPermutation (result);
        numExecute++;
      }

      Assert.Equal (totalPermutations, numExecute);
    }
  }
}