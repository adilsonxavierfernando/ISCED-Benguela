using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Modelos.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISCED_Benguela.Pages.Admin.Formacao
{
    public class ChangeModel : PageModel
    {
        private readonly CursosRepository repository;
        [BindProperty]
         public FormacaoDTO formDTO { get; set; }
        public ChangeModel(CursosRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
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

                var post = await repository.PostFormacaoAsync(formDTO);
                if (post != null)
                {
                    TempData["successAlert"] = true;
                    TempData["successMessage"] = "Parab�ns, Mais um N�vel Formativo foi adicionado para a Universidade.";
                    return RedirectToPage("/Admin/Formacao/Index");
                }
                else
                {
                    TempData["successAlert"] = false;
                    TempData["successMessage"] = "Opa!, n�o foi poss�vel avan�ar com seu pedido, porfavor, consulte a assist�ncia t�cnica ou tente novamente";
                    return Page();
                }
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
