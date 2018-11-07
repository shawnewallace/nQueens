using nqueens.lib.models;
using Xunit;

namespace nqueens.lib.tests
{
  public class NQueensBoardTransformerTests {

    private NQueensBoardTransformer _transformer;
    private NQueensBoard _board;

    public NQueensBoardTransformerTests()
    {
      _board = new NQueensBoard(new[] { 7, 3, 0, 2, 5, 1, 6, 4 });
      _transformer = new NQueensBoardTransformer();
    }

    [Fact]
    public void over_x_axis()
    {
      var expectedValues = new[] { 0, 4, 7, 5, 2, 6, 1, 3 };

      NQueensBoard rotatedBoard = _transformer.ReflectOverXAxis(_board);
      var rotatedBoardValues = rotatedBoard.ToIntArray();

      for (var i = 0; i < _board.N; i++)
      {
        Assert.Equal(expectedValues[i], rotatedBoardValues[i]);
      }
    }

    [Fact]
    public void over_y_axis()
    {
      var expectedValues = new[] { 4, 6, 1, 5, 2, 0, 3, 7 };

      NQueensBoard rotatedBoard = _transformer.ReflectOverYAxis(_board);
      var rotatedBoardValues = rotatedBoard.ToIntArray();

      for (var i = 0; i < _board.N; i++)
      {
        Assert.Equal(expectedValues[i], rotatedBoardValues[i]);
      }
    }

    [Fact]
    public void flip_over_forward_diagonal()
    {
      var expectedValues = new[] { 2, 5, 3, 1, 7, 4, 6, 0 };

      NQueensBoard rotatedBoard = _transformer.ReflectOverYEqualsX(_board);
      var rotatedBoardValues = rotatedBoard.ToIntArray();

      for (var i = 0; i < _board.N; i++)
      {
        Assert.Equal(expectedValues[i], rotatedBoardValues[i]);
      }
    }

    [Fact]
    public void transpose()
    {
      var expectedValues = new[] { 7, 1, 3, 0, 6, 4, 2, 5 };

      NQueensBoard rotatedBoard = _transformer.ReflectOverYEqualsMinusX(_board);
      var rotatedBoardValues = rotatedBoard.ToIntArray();

      for (var i = 0; i < _board.N; i++)
      {
        Assert.Equal(expectedValues[i], rotatedBoardValues[i]);
      }
    }

    [Fact]
    public void rotate_90_degrees()
    {
      var expectedValues = new[] { 0,6,4,7,1,3,5,2};

      NQueensBoard rotatedBoard = _transformer.Rotate90Degrees(_board);
      var rotatedBoardValues = rotatedBoard.ToIntArray();

      for (var i = 0; i < _board.N; i++)
      {
        Assert.Equal(expectedValues[i], rotatedBoardValues[i]);
      }
    }

    [Fact]
    public void rotate_180_degrees()
    {
      var expectedValues = new[] { 3,1,6,2,5,7,4,0 };

      NQueensBoard rotatedBoard = _transformer.Rotate180Degrees(_board);
      var rotatedBoardValues = rotatedBoard.ToIntArray();

      for (var i = 0; i < _board.N; i++)
      {
        Assert.Equal(expectedValues[i], rotatedBoardValues[i]);
      }
    }

    [Fact]
    public void rotate_270_degrees()
    {
      var expectedValues = new[] { 5,2,4,6,0,3,1,7 };

      NQueensBoard rotatedBoard = _transformer.Rotate270Degrees(_board);
      var rotatedBoardValues = rotatedBoard.ToIntArray();

      for (var i = 0; i < _board.N; i++)
      {
        Assert.Equal(expectedValues[i], rotatedBoardValues[i]);
      }
    }
  }
}