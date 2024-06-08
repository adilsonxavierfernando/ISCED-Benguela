using ISCED_Benguela.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ISCED_Benguela.Pages.ViewComponents
{
    public class SocialLinksViewComponent:ViewComponent
    {
        private readonly InfoSiteRepository repository;

        public SocialLinksViewComponent(InfoSiteRepository repository)
        {
            this.repository = repository;
        }
        public IViewComponentResult Invoke()
        {
            var result = repository.GetInfoSiteAsync();
            return View(result);
        }
    }
}
