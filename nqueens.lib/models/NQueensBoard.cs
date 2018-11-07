using System;

namespace nqueens.lib.models {
  public class NQueensBoard {
    public int N { get; private set; }
    private int[] _board;

    public int this [int i] {
      get { return _board[i]; }
      set { _board[i] = value; }
    }

    public bool IsQueenAt (int x, int y) => _board[x] == y;

    public void SetQueen (int x, int y) => _board[x] = y;

    public int[] ToIntArray => _board;

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