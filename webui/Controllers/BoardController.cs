using System;
using System.Web;
using System.Web.Mvc;
using nQueens.lib;
using webui.Models;

namespace webui.Controllers
{
  public class BoardController : Controller
  {
    // GET: Board
    public ActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Solutions(int n)
    {
      var solver = new Solver(n);
      var solutions = solver.Solve();
      var model = new SolutionModel(solutions);

      return View(model);
    }
  }
}