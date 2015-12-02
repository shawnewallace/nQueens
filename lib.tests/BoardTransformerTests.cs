using NUnit.Framework;

namespace nQueens.lib.tests
{
  [TestFixture]
  public class BoardTransformerTests
  {
    private BoardTransformer _transformer;
    private Board _board;

    [SetUp]
    public void SetUp()
    {
      _board = new Board(new[] { 7, 3, 0, 2, 5, 1, 6, 4 });
      _transformer = new BoardTransformer();
    }

    [Test]
    public void over_x_axis()
    {
      var expectedValues = new[] { 0, 4, 7, 5, 2, 6, 1, 3 };

      var rotatedBoard = _transformer.ReflectOverXAxis(_board);
      var rotatedBoardValues = rotatedBoard.ToIntArray();

      for (var i = 0; i < _board.N; i++)
      {
        Assert.AreEqual(expectedValues[i], rotatedBoardValues[i]);
      }
    }

    [Test]
    public void over_y_axis()
    {
      var expectedValues = new[] { 4, 6, 1, 5, 2, 0, 3, 7 };

      var rotatedBoard = _transformer.ReflectOverYAxis(_board);
      var rotatedBoardValues = rotatedBoard.ToIntArray();

      for (var i = 0; i < _board.N; i++)
      {
        Assert.AreEqual(expectedValues[i], rotatedBoardValues[i]);
      }
    }

    [Test]
    public void flip_over_forward_diagonal()
    {
      var expectedValues = new[] { 2, 5, 3, 1, 7, 4, 6, 0 };

      var rotatedBoard = _transformer.ReflectOverYEqualsX(_board);
      var rotatedBoardValues = rotatedBoard.ToIntArray();

      for (var i = 0; i < _board.N; i++)
      {
        Assert.AreEqual(expectedValues[i], rotatedBoardValues[i]);
      }
    }

    [Test]
    public void transpose()
    {
      var expectedValues = new[] { 7, 1, 3, 0, 6, 4, 2, 5 };

      var rotatedBoard = _transformer.ReflectOverYEqualsMinusX(_board);
      var rotatedBoardValues = rotatedBoard.ToIntArray();

      for (var i = 0; i < _board.N; i++)
      {
        Assert.AreEqual(expectedValues[i], rotatedBoardValues[i]);
      }
    }

    [Test]
    public void rotate_90_degrees()
    {
      var expectedValues = new[] { 0,6,4,7,1,3,5,2};

      var rotatedBoard = _transformer.Rotate90Degrees(_board);
      var rotatedBoardValues = rotatedBoard.ToIntArray();

      for (var i = 0; i < _board.N; i++)
      {
        Assert.AreEqual(expectedValues[i], rotatedBoardValues[i]);
      }
    }

    [Test]
    public void rotate_180_degrees()
    {
      var expectedValues = new[] { 3,1,6,2,5,7,4,0 };

      var rotatedBoard = _transformer.Rotate180Degrees(_board);
      var rotatedBoardValues = rotatedBoard.ToIntArray();

      for (var i = 0; i < _board.N; i++)
      {
        Assert.AreEqual(expectedValues[i], rotatedBoardValues[i]);
      }
    }

    [Test]
    public void rotate_270_degrees()
    {
      var expectedValues = new[] { 5,2,4,6,0,3,1,7 };

      var rotatedBoard = _transformer.Rotate270Degrees(_board);
      var rotatedBoardValues = rotatedBoard.ToIntArray();

      for (var i = 0; i < _board.N; i++)
      {
        Assert.AreEqual(expectedValues[i], rotatedBoardValues[i]);
      }
    }
  }
}