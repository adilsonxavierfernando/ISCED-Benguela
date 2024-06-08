using ISCED_Benguela.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISCED_Benguela.Pages.Formacao.Cursos
{
    public class IndexModel : PageModel
    {
        private readonly CursosRepository repository;
        public List<Modelos.Cursos> GetCursos { get; set; }

        public IndexModel(CursosRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                GetCursos = await repository.GetCursosAsync();
                
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
                var result = await this.repository.DeletetCursoAsync(id);
                if (result)
                {
                    TempData["successAlert"] = true;
                    TempData["successMessage"] = "O Curso foi deletado com sucesso";
                }
                else
                {
                    TempData["successAlert"] = false;
                    TempData["InSuccessMessage"] = "Não foi possível deletar o curso";
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
