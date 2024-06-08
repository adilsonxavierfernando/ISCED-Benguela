using ISCED_Benguela.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISCED_Benguela.Pages.Admin.InfoSite.Banner
{
    public class IndexModel : PageModel
    {
        private readonly BannerRepository repository;

        public IndexModel(BannerRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var result = await repository.GetAllAsync();
                if (result is not null)
                {
                    ViewData["dados"]=result;
                }
                return Page();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
