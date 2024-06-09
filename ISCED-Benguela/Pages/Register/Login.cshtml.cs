using ISCED_Benguela.Data.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ISCED_Benguela.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ISCED_Benguela.Encapsulamento;

namespace ISCED_Benguela.Pages.Register
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly RegisterRepository context;
        private readonly EstudanteRepository estudanteRepository;
        private readonly ProfessorRepository professorRepository;

        [BindProperty]
        public string Usuario { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public bool Rember { get; set; }
        public LoginModel(RegisterRepository context, EstudanteRepository estudanteRepository, ProfessorRepository professorRepository)
        {
            this.context = context;
            this.estudanteRepository = estudanteRepository;
            this.professorRepository = professorRepository;
        }
        public async Task<IActionResult> OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        } 
        string pagina;
        string NomeLogado { get; set; }
        string IdUserLogado { get; set; }

        public async Task<IActionResult> OnPostRecoveryAsync()
        {
            var result = await context.Login(this.Usuario, this.Password);
            if (result != null)
            {
                var mail = new SendMailService();
                string body = $"<h1>Olá,{result.Usuario} </h1>" +
                    $"<p>Suas credenciais para acessar o portal estão a baixo: </p>" +
                    $"<b>Senha:</b> {result.Password}<br>" +
                    $"<b>Username:</b>{result.Usuario}<hr><center><b>Portal Isced-benguela</b> - pela formação superior de  melhores educadores. </center>";
                await mail.SendEmail(result.Usuario, "Recuperação de Credenciais", body, true);
                TempData["SuccessMessage"] = true;
                TempData["SuccessMessageContent"] = "Sua senha foi recuperada com sucesso, consulte seu E-mail para ver a mesma e voltar a Iniciar Sessão no portal.";
            }
            else
            {
                TempData["SuccessMessage"] = false;
                TempData["SuccessMessageContent"] = "Nenhuma conta está associada ao E-mail informado";
            }
            return RedirectToPage();
        }
        public async Task<IActionResult>  OnPost() 
        {
            try
            {
                var result = await context.Login(this.Usuario, this.Password);
                if (result !=null)
                {

                    var rr = result;
                    if (result.Role == Modelos.Enums.EnumRole.Professor)
                    {
                        TempData["SuccessMessage"] = true;
                        pagina = "/Admin/index";
                        var r = await context.GetProfessorAsync(result.ID);
                        if (r != null)
                        {
                            NomeLogado = r.Nome + " " + r.Sobrenome;
                            IdUserLogado = r.ID.ToString();
                        }
                        else
                        {
                            TempData["SuccessMessage"] = false;
                            TempData["SuccessMessageContent"] = "Este Utilizador não tem permissão para iniciar";
                            return Page();
                        }
                    }
              
                    if (result.Role == Modelos.Enums.EnumRole.Anonymous || result.Role == Modelos.Enums.EnumRole.Admin)
                    {
                        TempData["SuccessMessage"] = true;
                        pagina = "/Admin/index";
                        var r = await context.GetUsuarioAsync(result.ID);
                        if (r != null)
                        {
                            NomeLogado = r.Nome + " " + r.Sobrenome;
                            IdUserLogado = r.ID.ToString();
                        }
                    }
                    if (result.Role == Modelos.Enums.EnumRole.Aluno)
                    {
                        TempData["SuccessMessage"] = true;
                        pagina = "/Index";
                        var r=await context.GetEstudantesAsync(result.ID);
                        if(r!=null)
                        {
                            NomeLogado = r.Nome + " " + r.Sobrenome;
                            IdUserLogado = r.ID.ToString();
                        }
                        else
                        {
                            TempData["SuccessMessage"] = false;
                            TempData["SuccessMessageContent"] = "Este Utilizador não tem permissão para iniciar";
                            return Page();
                        }
                    }
               
                  

                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, NomeLogado),
                        new Claim(ClaimTypes.Email, result.Usuario),
                        new Claim(ClaimTypes.NameIdentifier, IdUserLogado),
                        new Claim(ClaimTypes.Role, result.Role.ToString())
                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent=Rember,
                        RedirectUri=pagina
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                    

                    return Page();
                }
                else 
                {
                    TempData["SuccessMessage"] = false;
                    TempData["SuccessMessageContent"] = "Não conseguimos iniciar sua sessão! Verifique suas credenciais";
                    return Page();
                }
               
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> OnGetLogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            if (User.IsInRole("Aluno"))
            {
                await estudanteRepository.AtivarChatEstudanteAsync(Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value),false);
            }else if (User.IsInRole("Professor"))
            {
                await professorRepository.AtivarProfessorAsync(Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value),false);
            }

            return RedirectToPage(); // Redireciona para a página inicial após o logout
        }

    }
}
