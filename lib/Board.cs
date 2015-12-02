using System.Linq;

namespace nQueens.lib
{
  public class Board
  {
    public int N { get; set; }
    private readonly int[] _values;

    public int this[int i]
    {
      get { return _values[i]; }
      set { _values[i] = value; }
    }

    public int[] ToIntArray()
    {
      return _values;
    }

    public Board(int n)
    {
      N = n;
      _values = new int[N];
    }

    public Board(int[] initialValues)
    {
      N = initialValues.Count();
      _values = initialValues;
    }

    public bool ThereIsAQueenAt(int x, int y)
    {
      return _values[y] == x;
    }
  }
}