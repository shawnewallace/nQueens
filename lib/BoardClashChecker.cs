namespace nQueens.lib
{
  public class BoardClashChecker : IExecute<Board, bool>
  {
    public bool Execute(Board board)
    {
      for (var col = 1; col < board.N; col++)
      {
        var checker = new BoardDiagonalChecker();
        if (checker.Execute(board, col)) return true;
      }
      return false;
    }
  }
}