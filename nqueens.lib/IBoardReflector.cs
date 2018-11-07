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
}