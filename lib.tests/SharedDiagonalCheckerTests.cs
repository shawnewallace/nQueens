using System.Data;
using nQueens.lib;
using NUnit.Framework;

namespace nQueens.lib.tests
{
  [TestFixture]
  public class SharedDiagonalCheckerTests
  {
    [TestCase(5, 2, 2, 0, false)]
    [TestCase(5, 2, 3, 0, true)]
    [TestCase(5, 2, 4, 3, true)]
    [TestCase(5, 2, 4, 1, true)]
    public void should_be(int x0, int y0, int x1, int y1, bool expected)
    {
      var checker = new SharedDiagonalChecker();
      var c0 = new Coordinate(x0, y0);
      var c1 = new Coordinate(x1, y1);
      Assert.AreEqual(expected, checker.Execute(c0, c1));
    }
  }
}
