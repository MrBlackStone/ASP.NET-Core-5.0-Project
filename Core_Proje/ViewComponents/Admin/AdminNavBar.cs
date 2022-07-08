using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Admin
{
    public class AdminNavBar:ViewComponent
    {
        // Burada sadece VİEWBAG'leri taşımak olacak.
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
