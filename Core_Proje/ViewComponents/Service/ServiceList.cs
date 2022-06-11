using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Service
{
    public class ServiceList:ViewComponent
    {
        AboutManager am = new AboutManager(new EfAboutDal());
        public IViewComponentResult Invoke()
        {
            var values = am.TGetList();
            return View(values);
        }
    }
}
