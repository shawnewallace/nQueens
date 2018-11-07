using System;
using System.Linq;
using nqueens.lib.models;

namespace nqueens.lib
{
public interface IBoardReflector
  {
    NQueensBoard ReflectOverXAxis(NQueensBoard board);
    NQueensBoard ReflectOverYAxis(NQueensBoard board);
    NQueensBoard ReflectOverYEqualsX(NQueensBoard board);
    NQueensBoard ReflectOverYEqualsMinusX(NQueensBoard board);
  }

  public interface IBoardRotator
  {
    NQueensBoard Rotate90Degrees(NQueensBoard board);
    NQueensBoard Rotate180Degrees(NQueensBoard board);
    NQueensBoard Rotate270Degrees(NQueensBoard board);
  }

  public class NQueensBoardTransformer : IBoardReflector, IBoardRotator
  {
    public NQueensBoard ReflectOverXAxis(NQueensBoard board)
    {
      var newBoard = new NQueensBoard(board.N);

      var maxIndex = board.N - 1;

      for (var i = 0; i < board.N; i++)
      {
        newBoard[i] = maxIndex - board[i];
      }

      return newBoard;
    }

    public NQueensBoard ReflectOverYAxis(NQueensBoard board)
    {
      var values = board.ToIntArray().Reverse().ToArray();
      return new NQueensBoard(values);
    }

    public NQueensBoard ReflectOverYEqualsX(NQueensBoard board)
    {
      var newBoard = new NQueensBoard(board.N);

      for (var i = 0; i < board.N; i++)
      {
        newBoard[board[i]] = i;
      }

      return newBoard;
    }

    public NQueensBoard ReflectOverYEqualsMinusX(NQueensBoard board)
    {
      var newBoard = new NQueensBoard(board.N);
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

    public NQueensBoard Rotate90Degrees(NQueensBoard board)
    {
      var newBoard = new NQueensBoard(board.N);
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

    public NQueensBoard Rotate180Degrees(NQueensBoard board)
    {
      var newBoard = new NQueensBoard(board.N);
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

    public NQueensBoard Rotate270Degrees(NQueensBoard board)
    {
      var newBoard = new NQueensBoard(board.N);
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