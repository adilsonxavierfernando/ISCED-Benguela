using ISCED_Benguela.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISCED_Benguela.Pages.Admin.Formacao.Disciplina
{
    public class IndexModel : PageModel
    {
        private readonly DisciplinaRepository repository;
        public List<Modelos.Disciplina> GetDisciplina { get; set; }

        public IndexModel(DisciplinaRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> OnGet()
        {
            try
            {
                GetDisciplina = await repository.GetDisciplinaAsync();

                return Page();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            try
            {
                var result = await this.repository.DeleteDisciplinaAsync(id);
                if (result)
                {
                    TempData["successAlert"] = true;
                    TempData["successMessage"] = "A Disciplina foi deletada com sucesso";
                }
                else
                {
                    TempData["successAlert"] = false;
                    TempData["InSuccessMessage"] = "Não foi possível deletar a Disciplina";
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
