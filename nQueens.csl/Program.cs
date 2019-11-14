using System;
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
      for (var n = 1; n <= 11; n++)
      {
        var solver = new NQueensSolver(n: n);
        var results = solver.Solve(uniqueSolutions: true);

        Console.WriteLine($"There were {results.Count, 3} total UNIQUE solutions for N of {n, 3}.");
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