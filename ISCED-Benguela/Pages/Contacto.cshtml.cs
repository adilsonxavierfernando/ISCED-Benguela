using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Modelos;
using ISCED_Benguela.Modelos.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing.Drawing2D;

namespace ISCED_Benguela.Pages
{
    public class ContactoModel : PageModel
    {
        private readonly InfoSiteRepository repository;
        public InfoSite info { get; set; }
        [BindProperty]
        public FeedbackDTO modelo { get; set; }

        public ContactoModel(InfoSiteRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> OnGet()
        {
            try
            {
                info = await repository.GetInfoSiteAsync();
                return Page();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //envio de feedback
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var post = await repository.PostFeedbackAsyn(modelo);
                if (post != null)
                {
                    TempData["successAlert"] = true;
                    return RedirectToPage();
                }
                else
                {
                    TempData["successAlert"] = false;
                    Console.WriteLine("A reação não foi enviada");
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
