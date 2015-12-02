using System.Collections.Generic;
using System.Linq;
using nQueens.lib;

namespace webui.Models
{
  public class SolutionModel
  {
    public SolutionModel(List<Board> solutions)
    {
      TotalSolutions = solutions.Count;
      N = solutions.FirstOrDefault().N;
      Solutions = solutions;
    }

    public List<Board> Solutions { get; set; }

    public int N { get; set; }

    public int TotalSolutions { get; set; }
  }
}