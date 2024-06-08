using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Modelos;
using ISCED_Benguela.Modelos.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ISCED_Benguela.Pages.Admin.Materia
{
    public class InsertNovoModel : PageModel
    {
        private readonly DisciplinaRepository disciplina;
        private readonly DepartamentosRepository departamentos;
        private readonly MateriaRepository repository;

        [BindProperty]
        public MateriaDTO model { get; set; }
        public List<Disciplina> lstDisciplinas { get; set; }
        public List<Modelos.Departamentos> lstDepartamento { get; set; }
        public InsertNovoModel(DisciplinaRepository disciplina, DepartamentosRepository departamentos, MateriaRepository repository)
        {
            this.disciplina = disciplina;
            this.departamentos = departamentos;
            this.repository = repository;
        }
        public async Task OnGet()
        {
            lstDisciplinas = await disciplina.GetDisciplinaAsync();
            lstDepartamento = await departamentos.GetDepartamentosAsync();
        }
        public async Task<IActionResult>  OnPostAsync()
        {
            try
            {
                 var post= await repository.PostMateriaAsync(model);
                if (post!=null)
                {
                    TempData["successAlert"] = true;
                    TempData["successMessage"] = "A Matéria Foi cadastrada, agora, você precisa publicar ela.";
                    return RedirectToPage();
                }
                else
                {
                    TempData["successAlert"] = false;
                    TempData["successMessage"] = "Por algum Motivo, sua matéria não foi cadastrada ):";
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
