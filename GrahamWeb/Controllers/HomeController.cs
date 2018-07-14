using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            var GS = new GrahamScan(points);
            var res = GS.GetSortPoints().ToList();
          //  res = GrahamWithSpiral.ReorderNoCrossing(points.ToList());
            return View(res);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            var points = new List<Point>();
            var xValues = collection["point.X"].Split(',').Select(Int32.Parse).ToList();
            var yValues = collection["point.Y"].Split(',').Select(Int32.Parse).ToList();
            for (int i = 0; i < xValues.Count; i++)
            {
                points.Add(new Point(xValues[i], yValues[i]));
            }

            points.Sort();

            if (collection["alg"].Equals("spiral"))
            {
                return View(GrahamWithSpiral.ReorderNoCrossing(points.ToList()));
            }
            else
            {
                return View(new GrahamScan(points).GetSortPoints().ToList());
            }
        }
    }
}