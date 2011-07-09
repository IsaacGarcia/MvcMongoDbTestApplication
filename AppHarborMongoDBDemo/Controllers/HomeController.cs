using System.Configuration;
using System.Web.Mvc;
using AppHarborMongoDBDemo.Models;
using MongoDB.Driver;

namespace AppHarborMongoDBDemo.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var thingies = GetCollection().FindAll();
			return View(thingies);
		}

		public ActionResult New()
		{
			return View();
		}

		public ActionResult Create(Thingy thingy)
		{
			var collection = GetCollection();
			collection.Insert(thingy);
			return RedirectToAction("Index");
		}

		private MongoCollection<Thingy> GetCollection()
		{
			var mongoUrl = new MongoUrl(ConfigurationManager.AppSettings.Get("MONGOHQ_URL"));
			var database = MongoDatabase.Create(mongoUrl);
			return database.GetCollection<Thingy>("Thingies");
		}
	}
}
