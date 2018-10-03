using Xunit;
using nqueens.lib.models;

namespace nqueens.lib.tests
{
  public class SolutionCheckerTests {
    [Fact]
    public void ValidSolutionReturnsTrue() {
      var board = new NQueensBoard(4);
      board.SetQueen(0, 1);
      board.SetQueen(1, 3);
      board.SetQueen(2, 0);
      board.SetQueen(3, 2);

      Assert.True(NQueensSolutionChecker.IsSolution(board));
    }

    [Fact]
    public void InValidSolutionIfQueenInSameRow() {
      var board = new NQueensBoard(4);
      board.SetQueen(0, 1);
      board.SetQueen(1, 3);
      board.SetQueen(2, 3);
      board.SetQueen(3, 2);

      Assert.False(NQueensSolutionChecker.IsSolution(board));
    }

    [Fact]
    public void InValidSolutionIfQueenInSameDiagonal() {
      var board = new NQueensBoard(new int[] { 1, 2, 3, 0 });

      Assert.False(NQueensSolutionChecker.IsSolution(board));
    }

    [Theory]
    [InlineData(new int[] { 6, 4, 2, 0, 5 }, true)]
    [InlineData(new int[] { 6, 4, 2, 0, 5, 7, 1, 3 }, true)]
    [InlineData(new int[] { 0, 1 }, false)]
    [InlineData(new int[] { 5, 6 }, false)]
    [InlineData(new int[] { 6, 5 }, false)]
    [InlineData(new int[] { 0, 6, 4, 3 }, false)]
    [InlineData(new int[] { 5, 0, 7 }, false)]
    [InlineData(new int[] { 2, 0, 1, 3 }, false)]
    public void should_be(int[] values, bool expected)
    {
      var board = new NQueensBoard(values);

      Assert.Equal(expected, NQueensSolutionChecker.IsSolution(board));
    }
  }
}