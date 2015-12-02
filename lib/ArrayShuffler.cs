using System;

namespace nQueens.lib
{
  public class ArrayShuffler : IExecute<int[], int[]>
  {
    private readonly Random _rng = new Random();

    public int[] Execute(int[] xs)
    {
      int[] keys = new int[xs.Length];
      for (var i = 0; i < xs.Length; i++)
        keys[i] = _rng.Next();

      Array.Sort(keys, xs);

      return xs;
    }
  }
}