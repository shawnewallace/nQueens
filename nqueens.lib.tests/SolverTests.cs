using System.Collections.Generic;
using nqueens.lib.models;
using Xunit;

namespace nqueens.lib.tests {

  public class SolverTests {
    [Fact]
    public void ASolverNeedsASize () {
      var solver = new NQueensSolver (4);

      Assert.Equal (4, solver.N);
    }

    [Fact]
    public void SolveReturnsANonNullListOfNQueensBoard () {
      var solver = new NQueensSolver (8);
      List<NQueensBoard> result = solver.Solve ();

      Assert.NotNull (result);
    }
  }

  public class NumSolutionTests {
    [Theory]
    [InlineData (1, 1)]
    [InlineData (2, 0)]
    [InlineData (3, 0)]
    [InlineData (4, 2)]
    [InlineData (5, 10)]
    [InlineData (6, 4)]
    [InlineData (7, 40)]
    [InlineData (8, 92)]
    [InlineData (9, 352)]
    // [InlineData(10, 724)]
    // [InlineData(11, 2680)]
    // [InlineData(12, 14200)]
    // [InlineData(13, 73712)]
    public void should_have_correct_number_of_total_solutions (int n, int expectedNumSolutions) {
      var solver = new NQueensSolver (n);
      var results = solver.Solve ();

      Assert.Equal (expectedNumSolutions, results.Count);
    }

    [Theory]
    [InlineData (1, 1)]
    [InlineData (2, 0)]
    [InlineData (3, 0)]
    [InlineData (4, 1)]
    [InlineData (5, 2)]
    [InlineData (6, 1)]
    [InlineData (7, 6)]
    [InlineData (8, 12)]
    [InlineData (9, 46)]
    //[InlineData(10, 92)]
    //[InlineData(11, 341)]
    //[InlineData(12, 1787)]
    //[InlineData(13, 9233)]
    public void should_have_correct_number_of_unique_solutions (int n, int expectedNumSolutions) {
      var solver = new NQueensSolver (n);
      var results = solver.Solve (true);

      Assert.Equal (expectedNumSolutions, results.Count);
    }
  }
}