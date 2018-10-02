using System.Collections.Generic;
using Xunit;
using nqueens.lib.models;

namespace nqueens.lib.tests
{
  public class SolverTests {
    [Fact]
    public void ASolverNeedsASize () {
      var solver = new NQueensSolver (4);

      Assert.Equal(4, solver.N);
    }

    [Fact]
    public void SolveReturnsANonNullListOfNQueensBoard () {
      var solver = new NQueensSolver(8);
      List<NQueensBoard> result = solver.Solve();

      Assert.NotNull(result);
    }
  }
}