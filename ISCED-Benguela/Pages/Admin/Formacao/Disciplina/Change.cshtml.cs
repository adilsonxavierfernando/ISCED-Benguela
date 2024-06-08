using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Modelos.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISCED_Benguela.Pages.Admin.Formacao.Disciplina
{
    public class ChangeModel : PageModel
    {
        private readonly DisciplinaRepository repository;
        private readonly DepartamentosRepository departamentosRepository;
        private readonly CursosRepository cursosRepository;

        [BindProperty]
        public DisciplinasDTO modeloDTO { get; set; }
        public List<Modelos.Departamentos> GetDepartamentos { get; set; }
        public List<Modelos.Cursos> GetCursos { get; set; }

        public ChangeModel(DisciplinaRepository repository, DepartamentosRepository departamentosRepository, CursosRepository cursosRepository)
        {
            this.repository = repository;
            this.departamentosRepository = departamentosRepository;
            this.cursosRepository = cursosRepository;
        }
        public async Task<IActionResult> OnGet()
        {
            try
            {
                GetCursos = await cursosRepository.GetCursosAsync();
                return Page();
            }
            catch (Exception)
            {

                throw;
            }
        }
        //criar
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var post = await repository.PostDisciplinaAsync(modeloDTO);
                if (post != null)
                {
                    TempData["successAlert"] = true;
                    TempData["successMessage"] = "Mais uma disciplina foi adicionada";
                    return RedirectToPage("/Admin/Formacao/Disciplina/Index");
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
