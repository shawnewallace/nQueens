namespace nqueens.lib.tests {
  public class NQueensBoard {
    public int N { get; private set; }

    public NQueensBoard (int n) {
      N = n;
    }

    public NQueensBoard (int[] values) {
      N = values.Length;
    }
  }
}