using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Modelos.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISCED_Benguela.Pages.Admin.InfoSite
{
    public class EditeModel : PageModel
    {
        private readonly InfoSiteRepository repository;
        [BindProperty]
        public Modelos.InfoSite ModeloView { get; set; }
     
        public EditeModel(InfoSiteRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                var result = await repository.GetInfoSiteAsync(id);
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
             
                var post = await repository.EditeInfoSiteAsync(ModeloView);
                if (post != null)
                {
                    TempData["successAlert"] = true;
                    TempData["successMessage"] = "As Alterações foram feitas com sucesso";
                    return RedirectToPage("/Admin/InfoSite/Index");
                }
                else
                {
                    TempData["successAlert"] = false;
                    TempData["successMessage"] = "Opa!, não foi possível avançar com seu pedido, porfavor, consulte a assistência têcnica ou tente novamente";
                    return Page();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
