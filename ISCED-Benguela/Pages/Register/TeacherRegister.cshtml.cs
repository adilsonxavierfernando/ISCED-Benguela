using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Modelos;
using ISCED_Benguela.Modelos.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Core.Types;

namespace ISCED_Benguela.Pages.Register
{
    public class TeacherRegisterModel : PageModel
    {
        [BindProperty]
        public ProfessorDTO ModeloProfessor { get; set; }
     
        [BindProperty]
        public bool AcceptTermo { get; set; }
        [BindProperty]
        public List<Disciplina> disciplinas { get; set; }
        [BindProperty]
        public List<Departamentos> departamentos { get; set; }
        
        private readonly ProfessorRepository repository;
        private readonly DepartamentosRepository dep;

        public TeacherRegisterModel(ProfessorRepository _repository, DepartamentosRepository dep)
        {
           //disciplinas = new List<Disciplina>()
           // {
           //   new Disciplina{ID=1, Departamento=new Modelos.Departamentos{ID=1}, NomeDisciplina="Matematica"},
           //   new Disciplina{ID=2, Departamento=new Modelos.Departamentos{ID=1}, NomeDisciplina="Fisica"},
           //   new Disciplina{ID=3, Departamento=new Modelos.Departamentos{ID=2}, NomeDisciplina="Portugues"},
           //   new Disciplina{ID=4, Departamento=new Modelos.Departamentos{ID=2}, NomeDisciplina="Literatura"},
           //   new Disciplina{ID=5, Departamento=new Modelos.Departamentos{ID=3}, NomeDisciplina="Geografia"},
           // };

           // departamentos = new List<Departamentos>()
           // {
           //   new Modelos.Departamentos{ID=1, NomeDepartamento="Ciencias Exactas"},
           //   new Modelos.Departamentos{ID=2, NomeDepartamento="Ciencias Geograficas"},
           //   new Modelos.Departamentos{ID=3, NomeDepartamento="Comunicação e Linguistica"},

           // };
            repository = _repository;
            this.dep = dep;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                departamentos = await dep.GetDepartamentosAsync();
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
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                    if (this.AcceptTermo)
                    {
                    ModeloProfessor.RegisterLogin.Role = Modelos.Enums.EnumRole.Professor;
                    ModeloProfessor.RegisterLogin.Usuario = ModeloProfessor.Contacto.Email;


                    var post = await repository.PostProfessorAsync(ModeloProfessor);
                    if (post != null)
                    {
                        TempData["successAlert"] = true;
                        return RedirectToPage();
                    }
          
                        return Page();
                    }
                    else
                    {
                        TempData["successAlert"] = false;
                   
                        return Page();
                    }
              
            }
            catch (Exception)
            {

                throw;
            }
        }

        public JsonResult OnGetCarregarDisciplinas(int DepId=1)
        {
            return new JsonResult(disciplinas.Where(x => x.Curso.ID == DepId));
        }
    }
}
