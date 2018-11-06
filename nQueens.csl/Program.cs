using System;
using System.Text;
using nqueens.lib;
using nqueens.lib.models;

namespace nqueens.csl {
  public class Program {
    private const int N = 10;

    public static void Main (string[] args) {
      var solver = new NQueensSolver (N);
      var results = solver.Solve ();

      foreach (var result in results) {
        WriteBoard(result);
      }

      Console.WriteLine ($"There were {results.Count} total solutions.");
    }

    private static void WriteBoard(NQueensBoard board)
    {
      var queenChar = 'Q';

      const string boardDelim = " BOARD ";
      var numDash = Math.Ceiling((((2*N)+1) - boardDelim.Length)/2.0);

      var dashes = new String('=', Convert.ToInt32(numDash));
      var finalDelim = dashes + boardDelim + dashes;
      //var finalDelim = numDash.ToString();

      Console.OutputEncoding = Encoding.UTF8;
      Console.WriteLine(finalDelim);
      Console.WriteLine(" " +string.Join(" ", board.ToIntArray()));
      for (var i = 0; i < N; i++)
      {
        for (var j = 0; j < N; j++)
        {
          Console.Write("|");
          Console.Write(board.IsQueenAt(j, i) ? queenChar : ' ');
        }
        Console.WriteLine("|");
      }
    }
  }
}