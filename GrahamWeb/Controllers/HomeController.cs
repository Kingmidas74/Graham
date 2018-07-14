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
        public ActionResult Index()
        {
            var points = PointCreator.ReadPointsFromFile(Server.MapPath(@"~/App_Data/input.txt"));
            var GS = new GrahamScan(points);
            var res = GS.GetSortPoints().ToList();
            return View(res);
        }
    }
}