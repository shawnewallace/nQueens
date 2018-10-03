using System;
using Xunit;
using nqueens.lib.models;

namespace nqueens.lib.tests
{
  public class SafeCheckerTests {
    [Theory]
    [InlineData(new int[]{ 0,1 }, false)]
    public void IsSafe (int[] values, bool expected) {
      var board = new NQueensBoard(values); 
    }
  }
}