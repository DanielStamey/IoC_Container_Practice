using IoC_Container_Practice.Models;
using System.Web.Mvc;

namespace IoC_Container_Practice.Controllers
{
    public class ProteinTrackerController : Controller
    {
        private IProteinTrackingService proteinTrackingService;

        public ProteinTrackerController(IProteinTrackingService proteinTrackingService)
        {
            this.proteinTrackingService = proteinTrackingService;
        }

        public ActionResult Index()
        {
            ViewBag.Total = proteinTrackingService.Total;
            ViewBag.Goal = proteinTrackingService.Goal;

            return View();
        }

        public ActionResult AddProtein(int amount)
        {
            proteinTrackingService.AddProtein(amount);

            ViewBag.Total = proteinTrackingService.Total;
            ViewBag.Goal = proteinTrackingService.Goal;

            return View("Index");
        }
    }
}
