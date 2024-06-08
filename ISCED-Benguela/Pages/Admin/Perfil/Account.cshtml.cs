using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Modelos.DTO;
using ISCED_Benguela.Modelos.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;

namespace ISCED_Benguela.Pages.Admin.Perfil
{
    public class AccountModel : PageModel
    {
        private readonly UsuarioRepository repository;
        private readonly ProfessorRepository professorRepository;

        [BindProperty]
        public UsuarioDTO Model { get; set; }
        [BindProperty]
        public bool NivelRoot { get; set; }
        [BindProperty]
        public bool NivelAdmin { get; set; }

        public AccountModel(UsuarioRepository repository,ProfessorRepository professorRepository)
        {
            this.repository = repository;
            this.professorRepository = professorRepository;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                return Page();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IActionResult> OnGetAtivoAsync(int id, bool isChecked)
        {
            var c = isChecked;
            var refererUrl = Request.Headers["Referer"].ToString();
            await professorRepository.AtivarProfessorAsync(id, isChecked);

            return Redirect(refererUrl);
        }
        //criar
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                Model.RegisterLogin.Role = NivelRoot ? EnumRole.Anonymous : EnumRole.Admin; 
                var post=await repository.PostUsuarioAsync(Model);
                if (post != null)
                {
                    TempData["successAlert"] = true;
                    TempData["successMessage"] = "Acabou de Adicionar mais um usuário da área de administração!.";
                    return RedirectToPage();
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
