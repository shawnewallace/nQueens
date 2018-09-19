using System;
using Xunit;

namespace nqueens.lib.tests
{
  public class SafeCheckerTests {
    [Theory]
    [InlineData(new int[]{ 0,1 }, false)]
    public void IsSafe (int[] values, bool b) {
      var board = new NQueensBoard(values);
    }
  }
}