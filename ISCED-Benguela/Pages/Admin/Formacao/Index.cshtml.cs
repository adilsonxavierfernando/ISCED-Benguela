using ISCED_Benguela.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISCED_Benguela.Pages.Admin.Formacao
{
    public class IndexModel : PageModel
    {
        private readonly CursosRepository repository;
        public List<Modelos.Formacao> LstFormacao { get; set; }

        public IndexModel(CursosRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
               LstFormacao=await repository.GetFormacaoAsync();
                return Page();
            }
            catch (Exception)
            {

                throw;
            }
        }
        //deletar
        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            try
            {
                var result = await this.repository.DeleteFormacaoAsync(id);
                if (result)
                {
                    TempData["successAlert"] = true;
                    TempData["successMessage"] = "A Formação foi deletada com sucesso";
                }
                else
                {
                    TempData["successAlert"] = false;
                    TempData["InSuccessMessage"] = "Não foi possível deletar a Formação";
                }
                return RedirectToPage();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
