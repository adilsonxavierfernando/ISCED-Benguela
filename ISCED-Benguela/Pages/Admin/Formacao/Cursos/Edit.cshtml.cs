using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Encapsulamento;
using ISCED_Benguela.Modelos.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISCED_Benguela.Pages.Admin.Formacao.Cursos
{
    public class EditModel : PageModel
    {
        private readonly CursosRepository repository;
        private readonly DepartamentosRepository departamentosRepository;

        [BindProperty]
        public UpdateCursosDTO modelo { get; set; }

        public EditModel(CursosRepository repository, DepartamentosRepository departamentosRepository)
        {
            this.repository = repository;
            this.departamentosRepository = departamentosRepository;
        }
        public async Task<IActionResult>  OnGetAsync(int id)
        {
            try
            {
                var result = await repository.GetCursosAsync(id);
                var resultDepartamento = await departamentosRepository.GetDepartamentosAsync();
                var formacao = await repository.GetFormacaoAsync();
                result.CapaCurso.Extensao = FileConversor.ByteToString(result.CapaCurso.Ficheiro);
                ViewData["curso"] = result;
                ViewData["departamento"] = resultDepartamento;
                ViewData["formacao"] = formacao;
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
              
                if (modelo.CapaCurso.Caminho is null)
                    modelo.CapaCurso = null;

                if (modelo.ArquivoCurso.Caminho is null)
                    modelo.ArquivoCurso = null;
                var result = await repository.PutCursoAsync(modelo);
                if (result)
                {
                    TempData["successAlert"] = true;
                    TempData["successMessage"] = "Actualização Concluída com sucesso.";
                    return RedirectToPage("/Admin/Formacao/Cursos/Index");
                }
                else
                {
                    TempData["successAlert"] = false;
                    TempData["successMessage"] = "Houve um problema na atualização ):";
                    return await OnGetAsync(modelo.ID);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
