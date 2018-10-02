using System;
using System.Collections.Generic;

namespace nqueens.lib
{
  public static class KnuthsPermutationsCalculator<T> where T : IComparable {
    /*
    Knuths
    1. Find the largest index j such that a[j] < a[j + 1]. If no such index exists, the permutation is the last permutation.
    2. Find the largest index l such that a[j] < a[l]. Since j + 1 is such an index, l is well defined and satisfies j < l.
    3. Swap a[j] with a[l].
    4. Reverse the sequence from a[j + 1] up to and including the final element a[n].
    */

    public static IList<T> GetNextPermutation(IList<T> elements)
    {
      var nextPerm = new T[elements.Count];

      for(var i = 0; i < elements.Count; i++)
      {
        nextPerm[i] = elements[i];
      }

      var largestIndex = -1;
      for(var i = nextPerm.Length - 2; i >= 0; i--){
        if(nextPerm[i].CompareTo(nextPerm[i + 1]) < 0){
          largestIndex = i;
          break;
        }
      }

      if (largestIndex < 0) return null;

      var largestIndex2 = -1;
      for (var i = nextPerm.Length - 1; i >= 0; i--)
      {
        if (nextPerm[largestIndex].CompareTo(nextPerm[i]) < 0)
        {
          largestIndex2 = i;
          break;
        }
      }

      var tmp = nextPerm[largestIndex];
      nextPerm[largestIndex] = nextPerm[largestIndex2];
      nextPerm[largestIndex2] = tmp;

      for (int i = largestIndex + 1, j = nextPerm.Length - 1; i < j; i++, j--)
      {
        tmp = nextPerm[i];
        nextPerm[i] = nextPerm[j];
        nextPerm[j] = tmp;
      }
      return nextPerm;
    }
  }
}