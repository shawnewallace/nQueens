using NUnit.Framework;

namespace nQueens.lib.tests
{
  [TestFixture]
  public class UniqueSolutuionsCheck
  {
    [TestCase(1, 1)]
    [TestCase(2, 0)]
    [TestCase(3, 0)]
    [TestCase(4, 1)]
    [TestCase(5, 2)]
    [TestCase(6, 1)]
    [TestCase(7, 6)]
    [TestCase(8, 12)]
    [TestCase(9, 46)]
    //[TestCase(10, 92)]
    //[TestCase(11, 341)]
    //[TestCase(12, 1787)]
    //[TestCase(13, 9233)]
    public void should_have_correct_number_of_unique_solutions(int n, int numSolutions)
    {
      var solver = new Solver(n);
      var results = solver.Solve();

      Assert.AreEqual(numSolutions, results.Count);
    }

    [TestCase(1, 1)]
    [TestCase(2, 0)]
    [TestCase(3, 0)]
    [TestCase(4, 2)]
    [TestCase(5, 10)]
    [TestCase(6, 4)]
    [TestCase(7, 40)]
    [TestCase(8, 92)]
    [TestCase(9, 352)]
    //[TestCase(10, 724)]
    //[TestCase(11, 2680)]
    //[TestCase(12, 14200)]
    //[TestCase(13, 73712)]
    public void should_have_correct_number_of_total_solutions(int n, int numSolutions)
    {
      var solver = new Solver(n);
      var results = solver.Solve(false);

      Assert.AreEqual(numSolutions, results.Count);
    }
  }
}