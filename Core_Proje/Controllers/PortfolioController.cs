using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioManager pm = new PortfolioManager(new EfPortfolioDal());
        public IActionResult Index()
        {
            ViewBag.v1 = "Portfolio Listesi";
            ViewBag.v2 = "Projelerim";
            ViewBag.v3 = "Portfolio Listesi";
            var values = pm.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddPortfolio()
        {
            ViewBag.v1 = "Portfolio Listesi";
            ViewBag.v2 = "Projelerim";
            ViewBag.v3 = "Portfolio Listesi";
            return View();
        }
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio p)
        {
            

            PortfolioValidator validations = new PortfolioValidator();
            ValidationResult results = validations.Validate(p);

            if(results.IsValid)
            {
                pm.TAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
        }

        public IActionResult DeletePortfolio(int id)
        {
            var values = pm.TGetByID(id);
            pm.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditPortfolio(int id)
        {
            ViewBag.v1 = "Düzenleme";
            ViewBag.v2 = "Portfolio";
            ViewBag.v3 = "Portfolio Güncelleme";
            var values = pm.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult EditPortfolio(Portfolio p)
        {
            PortfolioValidator validations = new PortfolioValidator();
            ValidationResult results = validations.Validate(p);

            if(results.IsValid)
            {
                pm.TUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
        }
    }
}
