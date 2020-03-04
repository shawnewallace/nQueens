using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Diagnostics;
using nqueens.lib;
using nqueens.lib.models;
using System.Collections.Generic;
using System.Linq;

namespace nQueens.functions
{
  public static class Solve
  {
    private const int x = 3;

    [FunctionName("Solve")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
        ILogger log)
    {
      log.LogInformation("NQUEENS: C# HTTP trigger function processed a request.");

      string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
      var data = JsonConvert.DeserializeObject<NQueensRequest>(requestBody);

      var watch = Stopwatch.StartNew();

      NQueensResult result;

      try
      {
        result = Shawn(data);
      }
      finally
      {
        watch.Stop();
      }

      log.LogInformation($"NQUEENS: There were {result.Count,x} total UNIQUE solutions for N of {data.N,x} executed in {watch.ElapsedMilliseconds,6} ms.");

      return new OkObjectResult(result);
    }

    public static NQueensResult Shawn(NQueensRequest req)
    {
      var solver = new NQueensSolver(n: req.N);
      var results = new List<NQueensBoard>();

      results = solver.Solve(calculateUniqueSolutionsOnly: req.UniqueSolutionsOnly);

      return new NQueensResult(req.N)
      {
        Results = results,
        UniqueSolutionsOnly = req.UniqueSolutionsOnly
      };
    }
  }

  public class NQueensRequest
  {
    public int N { get; set; }
    public bool UniqueSolutionsOnly { get; set; } = false;
  }

  public class NQueensResult
  {
    public int N { get; private set; }
    public int Count
    {
      get
      {
        return Results.Count();
      }
    }

    public List<NQueensBoard> Results { get; internal set; }
    public bool UniqueSolutionsOnly { get; internal set; }

    public NQueensResult(int n)
    {
      N = n;
    }
  }
}
