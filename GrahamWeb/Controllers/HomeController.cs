using System;
using System.Linq;
using System.Web.Mvc;
using GrahamAlg;

namespace GrahamWeb.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var points = PointCreator.ReadPointsFromFile(Server.MapPath(@"~/App_Data/input.txt"));
            var  res = GrahamWithSpiral.ReorderNoCrossing(points.ToList());
            return View(res);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            var xValues = collection["point.X"].Split(',').Select(Int32.Parse).ToList();
            var yValues = collection["point.Y"].Split(',').Select(Int32.Parse).ToList();
            var points = xValues.Select((t, i) => new Point(t, yValues[i])).ToList();
            return View(collection["alg"].Equals("spiral") ? GrahamWithSpiral.ReorderNoCrossing(points.ToList()) : Snake.Sort(points).ToList());
        }
    }
}