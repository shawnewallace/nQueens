using System;
using System.Collections.Generic;

namespace nqueens.lib {
  public static class KnuthsPermutationsCalculator<T> where T : IComparable {
    /*
    Knuths
    1. Find the largest index j such that a[j] < a[j + 1]. If no such index exists, the permutation is the last permutation.
    2. Find the largest index l such that a[j] < a[l]. Since j + 1 is such an index, l is well defined and satisfies j < l.
    3. Swap a[j] with a[l].
    4. Reverse the sequence from a[j + 1] up to and including the final element a[n].
    */

    public static IList<T> GetNextPermutation (IList<T> elements) {
      T[] nextPerm = initializeNextPermutation (elements);
      int largestIndexJ = determineLargestIndexJ (nextPerm);

      if (largestIndexJ < 0) return null; // no more

      int largestIndexL = determineLargestIndexL (nextPerm, largestIndexJ);

      swap (ref nextPerm[largestIndexJ], ref nextPerm[largestIndexL]);

      for (int i = largestIndexJ + 1, j = nextPerm.Length - 1; i < j; i++, j--) {
        swap (ref nextPerm[i], ref nextPerm[j]);
      }
      return nextPerm;
    }

    private static void swap (ref T x, ref T y) {
      var tmp = x;
      x = y;
      y = tmp;
    }

    /*
    1. Find the largest index j such that a[j] < a[j + 1]. If no such index exists, the permutation is the last permutation.
    */
    private static int determineLargestIndexL (T[] nextPerm, int largestIndex) {
      var largestIndex2 = -1;
      for (var i = nextPerm.Length - 1; i >= 0; i--) {
        if (nextPerm[largestIndex].CompareTo (nextPerm[i]) < 0) {
          largestIndex2 = i;
          break;
        }
      }

      return largestIndex2;
    }

    /*
    2. Find the largest index l such that a[j] < a[l]. Since j + 1 is such an index, l is well defined and satisfies j < l.
    */
    private static int determineLargestIndexJ (T[] nextPerm) {
      var largestIndex = -1;
      for (var i = nextPerm.Length - 2; i >= 0; i--) {
        if (nextPerm[i].CompareTo (nextPerm[i + 1]) < 0) {
          largestIndex = i;
          break;
        }
      }

      return largestIndex;
    }

    private static T[] initializeNextPermutation (IList<T> elements) {
      var nextPerm = new T[elements.Count];

      for (var i = 0; i < elements.Count; i++) {
        nextPerm[i] = elements[i];
      }

      return nextPerm;
    }
  }
}