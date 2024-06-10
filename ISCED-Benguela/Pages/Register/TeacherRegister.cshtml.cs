using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Modelos;
using ISCED_Benguela.Modelos.DTO;
using MailKit.Net.Smtp;
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
        private readonly UsuarioRepository usuarioRepository;

        public TeacherRegisterModel(ProfessorRepository _repository, DepartamentosRepository dep, UsuarioRepository usuarioRepository)
        {
            repository = _repository;
            this.dep = dep;
            this.usuarioRepository = usuarioRepository;
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

                if (this.AcceptTermo)
                {
                    ModeloProfessor.RegisterLogin.Role = Modelos.Enums.EnumRole.Professor;
                    ModeloProfessor.RegisterLogin.Usuario = ModeloProfessor.Contacto.Email;

                    if (!await usuarioRepository.VerifyEmailExistAsync(ModeloProfessor.RegisterLogin.Usuario))
                    {
                        var post = await repository.PostProfessorAsync(ModeloProfessor);
                        if (post != null)
                        {
                            TempData["successAlert"] = true;
                            return RedirectToPage();
                        }
                        else
                        {
                            TempData["successAlert"] = false;
                            TempData["InSuccessMessage"] = "Não conseguimos Criar sua Conta. Verifique seus dados";
                            return await OnGetAsync();
                        }
                    }
                    else
                    {
                        TempData["successAlert"] = false;
                        TempData["InSuccessMessage"] = "O e-mail que está tentando usar, já está sendo usado por outro utilizador";
                        return await OnGetAsync();
                    }
                    
                }
                else
                {
                    TempData["successAlert"] = false;
                    TempData["InSuccessMessage"] = "Não podemos criar sua conta quando não concorda com nossos termos";
                    return await OnGetAsync();
                }
              
            }
            catch (SmtpCommandException ex)
            {
                TempData["successAlert"] = false;
                TempData["InSuccessMessage"] = ex.Message;
                return await OnGetAsync();
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
