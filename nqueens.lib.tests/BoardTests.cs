using Xunit;
using nqueens.lib.models;

namespace nqueens.lib.tests
{

  public class BoardTests {
    [Fact]
    public void ABoardCanBeInitializedWithSize () {
      var board = new NQueensBoard (4);

      Assert.NotNull (board);
    }

    [Fact]
    public void AnInitializedBoardHasASizeOfN () {
      var board = new NQueensBoard (4);

      Assert.Equal (4, board.N);
    }

    [Fact]
    public void ABoardCanBeInitializedWithValues () {
      var values = new int[5];
      var board = new NQueensBoard (values);

      Assert.NotNull (board);
    }

    [Fact]
    public void AValuesInitializeBoardHasASizeOfValuesLength () {
      var valueLength = 8;
      var values = new int[valueLength];
      var board = new NQueensBoard (values);

      Assert.Equal (valueLength, board.N);
    }

    [Fact]
    public void SetQueenPutsQueenInCorrectPosition() {
      var board = new NQueensBoard(8);

      board.SetQueen(1, 3);

      Assert.True(board.IsQueenAt(1, 3));
    }

    [Fact]
    public void ToIntArrayReturnsValidList() {
      var board = new NQueensBoard(4);
      var result = board.ToIntArray();

      Assert.Equal(4, result.Length);
    }
  }
}