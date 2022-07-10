using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class FeatureController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
        
            ViewBag.v1 = "Düzenleme";
            ViewBag.v2 = "Öne Çıkanlar ";
            ViewBag.v3 = "Öne Çıkan Sayfası";
            // var values = pm.TGetByID(id);
            return View();

        }

        [HttpPost]
        public IActionResult EditSkill(Skill p)
        {

           // sm.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
