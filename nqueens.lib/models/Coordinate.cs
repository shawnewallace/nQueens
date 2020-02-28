using System;

namespace nqueens.lib.models {
  public class Coordinate {
    public int x, y;

    public Coordinate (int p1, int p2) {
      x = p1;
      y = p2;
    }

    public static bool AreEqual (Coordinate zero, Coordinate one) {
      var dy = Math.Abs (one.y - zero.y);
      var dx = Math.Abs (one.x - zero.x);
      return dx == dy;
    }
  }
}