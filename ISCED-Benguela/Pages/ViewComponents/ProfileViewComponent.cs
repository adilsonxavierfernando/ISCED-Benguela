using Microsoft.AspNetCore.Mvc;

namespace ISCED_Benguela.Pages.ViewComponents
{
    public class ProfileViewComponent:ViewComponent
    {
        public ProfileViewComponent()
        {
            
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
