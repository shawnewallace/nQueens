using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace nQueens.lib
{
  public interface IBoardReflector
  {
    Board ReflectOverXAxis(Board board);
    Board ReflectOverYAxis(Board board);
    Board ReflectOverYEqualsX(Board board);
    Board ReflectOverYEqualsMinusX(Board board);
  }

  public interface IBoardRotator
  {
    Board Rotate90Degrees(Board board);
    Board Rotate180Degrees(Board board);
    Board Rotate270Degrees(Board board);
  }

  public class BoardTransformer : IBoardReflector, IBoardRotator
  {
    public Board ReflectOverXAxis(Board board)
    {
      var newBoard = new Board(board.N);

      var maxIndex = board.N - 1;

      for (var i = 0; i < board.N; i++)
      {
        newBoard[i] = maxIndex - board[i];
      }

      return newBoard;
    }

    public Board ReflectOverYAxis(Board board)
    {
      var values = board.ToIntArray().Reverse().ToArray();
      return new Board(values);
    }

    public Board ReflectOverYEqualsX(Board board)
    {
      var newBoard = new Board(board.N);

      for (var i = 0; i < board.N; i++)
      {
        newBoard[board[i]] = i;
      }

      return newBoard;
    }

    public Board ReflectOverYEqualsMinusX(Board board)
    {
      var newBoard = new Board(board.N);
      var maxIndex = board.N - 1;

      for (var i = 0; i < board.N; i++)
      {
        var oldX = i;
        var oldY = board[i];

        var newX = maxIndex - oldY;
        var newY = maxIndex - oldX;

        newBoard[newX] = newY;
      }

      return newBoard;
    }

    public Board Rotate90Degrees(Board board)
    {
      var newBoard = new Board(board.N);
      var maxIndex = board.N - 1;

      for (var i = 0; i < board.N; i++)
      {
        var oldX = i;
        var oldY = board[i];

        var newX = maxIndex - oldY;
        var newY = oldX;

        newBoard[newX] = newY;
      }

      return newBoard;
    }

    public Board Rotate180Degrees(Board board)
    {
      var newBoard = new Board(board.N);
      var maxIndex = board.N - 1;

      for (var i = 0; i < board.N; i++)
      {
        var oldX = i;
        var oldY = board[i];

        var newX = maxIndex - oldX;
        var newY = maxIndex - oldY;

        newBoard[newX] = newY;
      }

      return newBoard;
    }

    public Board Rotate270Degrees(Board board)
    {
      var newBoard = new Board(board.N);
      var maxIndex = board.N - 1;

      for (var i = 0; i < board.N; i++)
      {
        var oldX = i;
        var oldY = board[i];

        var newX = oldY;
        var newY = maxIndex - oldX;

        newBoard[newX] = newY;
      }

      return newBoard;
    }
  }
}
