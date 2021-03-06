using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class SkillController : Controller
    {
        SkillManager sm = new SkillManager(new EfSkillDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Yetenek Listesi";
            ViewBag.v2 = "Yetenekler";
            ViewBag.v3 = "Yetenekler Listesi";
            var values = sm.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSkill()
        {
            ViewBag.v1 = "Yetenek Ekleme";
            ViewBag.v2 = "Yetenekler";
            ViewBag.v3 = "Yetenekler Ekleme";

            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {

            sm.TAdd(skill);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSkill(int id)
        {
            var values = sm.TGetByID(id);
            sm.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditSkill(int id)
        {
            ViewBag.v1 = "Düzenleme";
            ViewBag.v2 = "Yetenekler";
            ViewBag.v3 = "Yetenekler Güncelleme";
            var values = sm.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditSkill(Skill p)
        {

            sm.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
