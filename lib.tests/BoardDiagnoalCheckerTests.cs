using NUnit.Framework;

namespace nQueens.lib.tests
{
  [TestFixture]
  public class BoardDiagnoalCheckerTests
  {
    [TestCase(new int[] { 6, 4, 2, 0, 5 }, 4, false)]
    [TestCase(new int[] { 6, 4, 2, 0, 5, 7, 1, 3 }, 4, false)]
    [TestCase(new int[] { 0, 1 }, 1, true)]
    [TestCase(new int[] { 5, 6 }, 1, true)]
    [TestCase(new int[] { 6, 5 }, 1, true)]
    [TestCase(new int[] { 0, 6, 4, 3 }, 3, true)]
    [TestCase(new int[] { 5, 0, 7 }, 2, true)]
    [TestCase(new int[] { 2, 0, 1, 3 }, 1, false)]
    [TestCase(new int[] { 2, 0, 1, 3 }, 2, true)]
    public void should_be(int[] values, int col, bool expected)
    {
      var board = new Board(values);
      var checker = new BoardDiagonalChecker();
      var result = checker.Execute(board, col);

      Assert.AreEqual(expected, result);
    }
  }
}