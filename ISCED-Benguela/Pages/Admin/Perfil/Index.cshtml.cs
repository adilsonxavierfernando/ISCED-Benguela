using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Encapsulamento;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;

namespace ISCED_Benguela.Pages.Admin.Perfil
{
    public class IndexModel : PageModel
    {
        private readonly RegisterRepository register;
        private readonly ProfessorRepository professor;
        private readonly UsuarioRepository usuario;
        [BindProperty]
        public Modelos.Usuario userModel { get; set; }
        [BindProperty]
        public Modelos.Registro registerModel { get; set; }
        [BindProperty]
        public Modelos.Enderecos enderecoModel { get; set; }
        [BindProperty]
        public Modelos.Professores professorModel { get; set; }
        [BindProperty]
        public IFormFile Caminho { get; set; }
        [BindProperty]
        public int idFoto { get; set; }


        public IndexModel(RegisterRepository register, ProfessorRepository professor, UsuarioRepository usuario)
        {
            this.register = register;
            this.professor = professor;
            this.usuario = usuario;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                int idUser = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                userModel = await usuario.GetUsuarioAsync(idUser);
                if (User.IsInRole("Professor"))
                {
                    var p= await professor.GetProfessorByIdAsync(idUser);
                    p.Foto.Extensao = FileConversor.ByteToString(p.Foto.Ficheiro);

                    ViewData["Professor"] = p; 
                   // ViewData["usuario"] = await register.getpro
                }
             
                return Page();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IActionResult> OnPostUsuarioUpdateAsync()
        {
            try
            {
                if (userModel is not null) 
                {
                    var post = await usuario.UpdateUsuarioAsync(userModel);
                    if (post != null)
                    {
                        TempData["successAlert"] = true;
                        TempData["successMessage"] = "Dados de usuario alterados com sucesso";
                        return RedirectToPage();
                    }
                    else
                    {
                        TempData["successAlert"] = false;
                        TempData["successMessage"] = "Não foi possivel alterar os dados de usuarios";


                    }
                   
                }
                //atualizar só o registro
                if (registerModel is not null)
                {
                    var post = await register.UpdateSenhaAsync(registerModel);
                    if (post != null)
                    {
                        TempData["successAlert"] = true;
                        TempData["successMessage"] = "Senha alterada com sucesso";
                        return RedirectToPage();
                    }
                    else
                    {
                        TempData["successAlert"] = false;
                        TempData["successMessage"] = "Não foi possivel alterar a senha";


                    }

                }
                return Page();
            }
            catch (Exception)
            {

                throw;
            }
        }
        //senha
        public async Task<IActionResult> OnPostSenhaUpdateAsync()
        {
            try
            {
                //atualizar só o registro
                if (registerModel is not null)
                {
                    var post = await register.UpdateSenhaAsync(registerModel);
                    if (post)
                    {
                        TempData["successAlert"] = true;
                        TempData["successMessage"] = "Senha alterada com sucesso";
                        return RedirectToPage();
                    }
                    else
                    {
                        TempData["successAlert"] = false;
                        TempData["successMessage"] = "Não foi possivel alterar a senha";
                        return RedirectToPage();

                    }

                }
                return Page();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //alterar foto
        public async Task<IActionResult> OnPostFotoUpdateAsync()
        {
            try
            {
                //atualizar só o registro
                if (Caminho is not null)
                {
                    var post = await professor.UpdateFotoAsync(idFoto, Caminho);
                    if (post)
                    {
                        TempData["successAlert"] = true;
                        TempData["successMessage"] = "Foto alterada com sucesso";
                        return RedirectToPage();
                    }
                    else
                    {
                        TempData["successAlert"] = false;
                        TempData["InSuccessMessage"] = "Não foi possivel alterar a foto";

                        return RedirectToPage();
                    }

                }
                TempData["successAlert"] = false;
                TempData["InSuccessMessage"] = "Nenhuma foto foi selecionada";
                return RedirectToPage();
            }
            catch (Exception)
            {

                throw;
            }
        }


        //alterar dados Gerais
        public async Task<IActionResult> OnPostGeralUpdateAsync()
        {
            try
            {
                //atualizar só o registro
              
                    var post = await professor.UpdateGeralAsync(professorModel);
                    if (post)
                    {
                        TempData["successAlert"] = true;
                        TempData["successMessage"] = "Dados alterados com sucesso";
                        return RedirectToPage();
                    }
                    else
                    {
                        TempData["successAlert"] = false;
                        TempData["InSuccessMessage"] = "Não foi possivel alterar os dados";

                        return RedirectToPage();
                    }

            }
            catch (Exception)
            {

                throw;
            }
        }


        //alterar redes
        public async Task<IActionResult> OnPostSocialUpdateAsync()
        {
            try
            {
                //atualizar só o registro
               
                    var post = await professor.UpdateSocialAsync(professorModel);
                    if (post)
                    {
                        TempData["successAlert"] = true;
                        TempData["successMessage"] = "Dados alterados com sucesso";
                        return RedirectToPage();
                    }
                    else
                    {
                        TempData["successAlert"] = false;
                        TempData["InSuccessMessage"] = "Não foi possivel atualizar";

                        return RedirectToPage();
                    }

            
            }
            catch (Exception)
            {

                throw;
            }
        }

        //alterar endereco
        public async Task<IActionResult> OnPostEnderecoUpdateAsync()
        {
            try
            {
                //atualizar só o registro
              
                    var post = await professor.UpdateEnderecoAsync(professorModel);
                    if (post)
                    {
                        TempData["successAlert"] = true;
                        TempData["successMessage"] = "Dados alterados com sucesso";
                        return RedirectToPage();
                    }
                    else
                    {
                        TempData["successAlert"] = false;
                        TempData["InSuccessMessage"] = "Não foi possivel alterar os dados";

                        return RedirectToPage();
                    }

            
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
