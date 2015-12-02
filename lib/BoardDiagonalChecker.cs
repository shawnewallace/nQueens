namespace nQueens.lib
{
  public class BoardDiagonalChecker : IExecute<Board, int, bool>
  {
    /// <summary>
    /// Return true if the queen at column col clashes
    /// on the diagonal with any queen to its left.
    /// </summary>
    /// <param name="board"></param>
    /// <param name="col"></param>
    /// <returns></returns>
    public bool Execute(Board board, int col)
    {
      var checker = new SharedDiagonalChecker();
      for (var i = 0; i < col; i++)
      {
        var c1 = new Coordinate(i, board[i]);
        var c2 = new Coordinate(col, board[col]);

        if (checker.Execute(c1, c2))
          return true;
      }

      return false;
    }
  }
}