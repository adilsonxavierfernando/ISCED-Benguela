using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Modelos.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISCED_Benguela.Pages.Admin.Formacao
{
    public class EditModel : PageModel
    {
        private readonly CursosRepository repository;
        [BindProperty]
        public UpdateFormacaoID modelo { get; set; } 

        public EditModel(CursosRepository repository)
        {
            this.repository = repository;
        }

      

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
               var result= await repository.GetFormacaoByIdAsync(id);
                ViewData["formacao"]=result;
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
                
                var post = await repository.PutFormacaoAsync(modelo);
                if (post)
                {
                    TempData["successAlert"] = true;
                    TempData["successMessage"] = "Edição feita com sucesso";
                    return RedirectToPage("Index");
                }
                else
                {
                    TempData["successAlert"] = false;
                    TempData["successMessage"] = "Opa!, não foi possível avançar com seu pedido, porfavor, consulte a assistência têcnica ou tente novamente";
                    return await OnGetAsync(modelo.ID);
                }

            }
            catch (InvalidOperationException ioe)
            {
                TempData["successAlert"] = false;
                TempData["successMessage"] = ioe.Message;
                return await OnGetAsync(modelo.ID);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
