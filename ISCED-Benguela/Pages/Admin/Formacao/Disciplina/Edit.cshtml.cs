using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Modelos.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISCED_Benguela.Pages.Admin.Formacao.Disciplina
{
    public class EditModel : PageModel
    {
        private readonly CursosRepository repository;
        private readonly DisciplinaRepository disciplinaRepository;
        [BindProperty]
        public UpdateDisiciplinasDTO modelo { get; set; }

        public EditModel(CursosRepository repository, DisciplinaRepository disciplinaRepository)
        {
            this.repository = repository;
            this.disciplinaRepository = disciplinaRepository;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                var resultCursos = await repository.GetCursosAsync();
                var resultDisiciplina = await disciplinaRepository.GetDisciplinaAsync(id);

                ViewData["disiciplina"] = resultDisiciplina;
                ViewData["cursos"]= resultCursos;
                return Page();
            }
            catch (Exception)
            {

                throw;
            }
        }
        //
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {

                var post = await disciplinaRepository.putDisciplina(modelo);
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
