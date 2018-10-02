using Xunit;

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
  }
}