using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Modelos.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISCED_Benguela.Pages.Admin.InfoSite
{
    public class IndexModel : PageModel
    {
        private readonly InfoSiteRepository repository;

        [BindProperty]
        public Modelos.InfoSite ModeloView { get; set; }
        [BindProperty]
        public InfoSiteDTO ModeloDTO { get; set; }
        public IndexModel(InfoSiteRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var result = await repository.GetInfoSiteAsync();
                ModeloView = result;
                return Page();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var result = await repository.PostInfoAsync(ModeloDTO);
                if(result is not null)
                {
                    ModeloView = result;
                    TempData["successAlert"] = true;
                    TempData["successMessage"] = "Os dados do site foram inseridos com sucesso.";
                    return RedirectToPage();
                }
                TempData["successAlert"] = false;
                TempData["successMessage"] = "Não foi possivel proceder.";
                return Page();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
