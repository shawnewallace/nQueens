using System;
using System.Security.Cryptography.X509Certificates;

namespace nQueens.lib
{
  public class SharedDiagonalChecker : IExecute<Coordinate, Coordinate, bool>
  {
    public bool Execute(Coordinate zero, Coordinate one)
    {
      var dy = Math.Abs(one.y - zero.y);
      var dx = Math.Abs(one.x - zero.x);
      return dx == dy;
    }
  }
}