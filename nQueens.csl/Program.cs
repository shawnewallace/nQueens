using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using nqueens.lib;
using nqueens.lib.models;

namespace nqueens.csl
{
  public class Program
  {
    private const int N = 2;

    public static void Main(string[] args)
    {
      int nMax = 10;
      const int x = 3;

      for (var n = 1; n <= nMax; n++)
      {
        var solver = new NQueensSolver(n: n);
        var watch = Stopwatch.StartNew();
        var results = new List<NQueensBoard>();

        try
        {
          results = solver.Solve(calculateUniqueSolutionsOnly: true);
        }
        finally
        {
          watch.Stop();
        }

        Console.WriteLine($"There were {results.Count,3} total UNIQUE solutions for N of {n, x} executed in {watch.ElapsedMilliseconds,6} ms.");
        // foreach (var result in results)
        // {
        //   Console.WriteLine($"\t{result}");
        // }
      }


      // var solver = new NQueensSolver(n: N);
      // var results = solver.Solve(uniqueSolutions: true);

      // foreach (var result in results)
      // {
      //   WriteBoard(board: result);
      // }

      // Console.WriteLine($"There were {results.Count} total solutions.");
    }

    private static void WriteBoard(NQueensBoard board)
    {
      var queenChar = 'Q';

      const string boardDelim = " BOARD ";
      var numDash = Math.Ceiling((((2 * N) + 1) - boardDelim.Length) / 2.0);

      var dashes = new String('=', Convert.ToInt32(numDash));
      var finalDelim = ' ' + dashes + boardDelim + dashes;
      //var finalDelim = numDash.ToString();

      Console.OutputEncoding = Encoding.UTF8;
      Console.WriteLine(finalDelim);
      Console.WriteLine("  " + string.Join(" ", board.ToIntArray));
      for (var i = 0; i < N; i++)
      {
        Console.Write(i);
        for (var j = 0; j < N; j++)
        {
          Console.Write("|");
          Console.Write(board.IsQueenAt(j, i) ? queenChar : ' ');
        }
        Console.WriteLine("|");
      }
      Console.WriteLine("\n");
    }
  }
}