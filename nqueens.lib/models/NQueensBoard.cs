using System;

namespace nqueens.lib.models {
  /*
  New() creates an 8x8 board.
  board.Queens() returns the number of queens that are currently placed on the board. We will use this function to check if we have found a place for all the queens.
  board.AvailableFields() returns a list of coordinates which are not under attack and therefore available to place a queen there.
  board.PlaceQueen() takes coordinates as parameter and places a queen there if possible. It updates the board to mark all fields unavailable that are under attack.
  board.RemoveQueen() takes coordinates as parameter and removes the queen from the field addressed by the coordinates.
  board.Print() takes a Writer interface as parameter and writes a Unicode-powered human-readable representation of the state of the board to it. We will use it with os.Stdout to print the final result.
   */
  public class NQueensBoard {
    public int N { get; private set; }

    private int[] _board;

    public int this[int i]
    {
      get { return _board[i]; }
      set { _board[i] = value; }
    }

    public bool IsQueenAt(int x, int y)
    {
      return _board[x] == y;
    }

    public void SetQueen(int x, int y)
    {
      _board[x] = y;
    }

    public int[] ToIntArray()
    {
      return _board;
    }

    public NQueensBoard (int n) {
      N = n;
      _board = new int[N];
    }

    public NQueensBoard (int[] values) {
      N = values.Length;
      _board = values;
    }
  }
}