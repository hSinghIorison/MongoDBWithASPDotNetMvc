 using System.Web.Mvc;
using MongoDB.Bson;

namespace RealEstate.Controllers
{
    public class HomeController : Controller
    {
        public RealEstateContext Context = new RealEstateContext();
        public ActionResult Index()
        {
            var command = new BsonDocument { { "dbstats", 1 } };
            var stats = Context.Database.RunCommand<BsonDocument>(command);
            return Json(stats.ToJson(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}