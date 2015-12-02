using System;
using System.Linq;
using System.Runtime.InteropServices;
using NUnit.Framework;

namespace nQueens.lib.tests
{
  [TestFixture]
  public class BoardClashCheckerTests
  {
    [TestCase(new int[] { 6, 4, 2, 0, 5, 7, 1, 3 }, false)]
    [TestCase(new int[] { 4, 6, 2, 0, 5, 7, 1, 3 }, true)]
    [TestCase(new int[] { 0, 1, 2, 3 }, true)] // Try small 4x4 board
    [TestCase(new int[] { 2, 0, 3, 1 }, false)] // Solution to 4x4 case
    public void should_be(int[] values, bool expected)
    {
      var board = new Board(values);
      var checker = new BoardClashChecker();
      Assert.AreEqual(expected, checker.Execute(board));
    }
  }

  [TestFixture]
  public class ArrayShufflerTests
  {
    [Test]
    public void smoke()
    {
      var shuffler = new ArrayShuffler();
      var input = new int[] { 30, 10, 20 };
      var result = shuffler.Execute(input);
      Console.WriteLine(String.Join(",", result));
      Assert.IsNotEmpty(result);
    }
  }
}