using System;
using System.Linq;
using System.Web.Mvc;
using GrahamAlg;

namespace GrahamWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly SortFactory _sortFactory;
        private readonly PointCreator _pointCreator;

        public HomeController(SortFactory sortFactory, PointCreator pointCreator)
        {
            _sortFactory = sortFactory;
            _pointCreator = pointCreator;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var points = _pointCreator.ReadPointsFromFile(Server.MapPath(@"~/App_Data/input.txt"));
            var res = _sortFactory.CreateEndruHandler(points.ToList()).GetSortPoints();
            return View(res);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            var xValues = collection["point.X"].Split(',').Select(Int32.Parse).ToList();
            var yValues = collection["point.Y"].Split(',').Select(Int32.Parse).ToList();
            var points = xValues.Select((t, i) => new Point(t, yValues[i])).ToList();
            return View(collection["alg"].Equals("spiral") ? _sortFactory.CreateEndruHandler(points).GetSortPoints() : _sortFactory.CreateSnakeHandler(points).GetSortPoints());
        }
    }
}