using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Modelos.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISCED_Benguela.Pages.Formacao.Cursos
{
    public class ChangeModel : PageModel
    {
        private readonly CursosRepository repository;
        private readonly DepartamentosRepository departamentos;
        public List<Modelos.Formacao> LstFormacao { get; set; }
        public List<Modelos.Departamentos> GetDepartamentos { get; set; }
        [BindProperty]
        public CursosDTO modeloDTO { get; set; }

        public ChangeModel(CursosRepository repository, DepartamentosRepository departamentos)
        {
            this.repository = repository;
            this.departamentos = departamentos;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
            LstFormacao=await repository.GetFormacaoAsync();
            GetDepartamentos=await departamentos.GetDepartamentosAsync();
               return Page();
            }
            catch (Exception)
            {

                throw;
            }
        }
        //postar
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var post = await repository.PostCursoAsync(modeloDTO);
                if (post != null)
                {
                    TempData["successAlert"] = true;
                    TempData["successMessage"] = "Parabêns, sua Universidade agora tem mais um curso disponivel";
                    return RedirectToPage("/Admin/Formacao/Cursos/Index");
                }
                else
                {
                    TempData["successAlert"] = false;
                    TempData["successMessage"] = "Opa! Não deu para avançar com seu pedido. Porfavor consulte a assistência técnica";
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
