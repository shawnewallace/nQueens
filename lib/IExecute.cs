namespace nQueens.lib
{
  public interface IExecute<TP1, TP2, TResult>
  {
    TResult Execute(TP1 p1, TP2 p2);
  }

  public interface IExecute<TP1, TResult>
  {
    TResult Execute(TP1 p1);
  }
}