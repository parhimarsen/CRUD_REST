using System.Web.Mvc;
using Task1_2.Models;

namespace Task1_2.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork repository = new UnitOfWork();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View(repository);
        }

    }
}
