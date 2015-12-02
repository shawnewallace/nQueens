using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nQueens.lib;

namespace cons
{
  class Program
  {
    private const int N = 8;
    static void Main(string[] args)
    {
      var solver = new Solver(N);
      var results = solver.Solve();

      foreach (var result in results)
      {
        WriteBoard(result);
      }

      Console.WriteLine("There were {0} total solutions.", results.Count);

      Console.ReadLine();
    }

    private static void WriteBoard(Board board)
    {
      var queenChar = 'Q';

      Console.OutputEncoding = Encoding.UTF8;
      Console.WriteLine("=== BOARD ===");
      Console.WriteLine(" " +string.Join(" ", board.ToIntArray()));
      for (var i = 0; i < N; i++)
      {
        for (var j = 0; j < N; j++)
        {
          Console.Write("|");
          Console.Write(board.ThereIsAQueenAt(i, j) ? queenChar : ' ');
        }
        Console.WriteLine("|");
      }
    }
  }
}
