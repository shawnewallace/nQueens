using nqueens.lib.models;

namespace nqueens.lib
{
  public interface IBoardRotator
  {
    NQueensBoard Rotate90Degrees(NQueensBoard board);
    NQueensBoard Rotate180Degrees(NQueensBoard board);
    NQueensBoard Rotate270Degrees(NQueensBoard board);
  }
}