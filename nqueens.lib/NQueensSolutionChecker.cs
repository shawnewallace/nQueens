using System.Linq;
using nqueens.lib.models;

namespace nqueens.lib
{
  public static class NQueensSolutionChecker {
    public static bool IsSolution (NQueensBoard board) {
      if (CheckAcross (board)) return false;

      if (CheckDiagonals (board)) return false;

      return true;
    }

    private static bool CheckDiagonals(NQueensBoard board)
    {
      for (var col = 1; col < board.N; col++)
      {
        if (CheckIndividualDiagonal(board, col)) return true;
      }
      return false;
    }

    private static bool CheckIndividualDiagonal(NQueensBoard board, int col)
    {
      for (var i = 0; i < col; i++)
      {
        var c1 = new Coordinate(i, board.ToIntArray()[i]);
        var c2 = new Coordinate(col, board.ToIntArray()[col]);

        if (Coordinate.AreEqual(c1, c2))
          return true;
      }

      return false;
    }

    private static bool CheckAcross (NQueensBoard board) {
      var uniqueValues = board.ToIntArray ().Select (v => v).Distinct ();

      return (uniqueValues.Count () != board.N);
    }
  }
}