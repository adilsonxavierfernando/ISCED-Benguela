using ISCED_Benguela.Data.Context;
using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Modelos;
using ISCED_Benguela.Modelos.DTO;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.ObjectModel;

namespace ISCED_Benguela.Pages.Register
{
    public class StudentRegisterModel : PageModel
    {
        [BindProperty]
        public EstudanteDTO estudante { get; set; }
        [BindProperty]
        public bool TermoAccept { get; set; }
        [BindProperty]
        //public SelectList lsCursos { get; set; }
        public Collection<Modelos.Cursos> Cursos { get; set; }

       
        private readonly EstudanteRepository repository;
        private readonly CursosRepository cursosRepository;

        public StudentRegisterModel(EstudanteRepository repository, CursosRepository cursosRepository)
        {
         
            this.repository = repository;
            this.cursosRepository = cursosRepository;
            //lsCursos = new SelectList(new Collection<Modelos.Cursos>()
            //{
            //    new Modelos.Cursos() { Formacao=new Modelos.Formacao{ID=1, NomeFormacao="Licenciatura"}, NomeCurso="Matemátiva"},
            //    new Modelos.Cursos() { Formacao=new Modelos.Formacao{ID=1, NomeFormacao="Licenciatura"}, NomeCurso="Língua Portuguesa"},
            //    new Modelos.Cursos() { Formacao=new Modelos.Formacao{ID=1, NomeFormacao="Licenciatura"}, NomeCurso="Letras"},
            //    new Modelos.Cursos() { Formacao=new Modelos.Formacao{ID=1, NomeFormacao="Licenciatura"}, NomeCurso="Inglês"},
            //},"ID","NomeCurso");
        }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
               Cursos=new Collection<Modelos.Cursos>(await cursosRepository.GetCursosAsync());
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
                if (this.TermoAccept)
                {
                    estudante.RegisterLogin.Role = Modelos.Enums.EnumRole.Aluno;
                    estudante.RegisterLogin.Usuario = estudante.Contactos.Email;
                    
                    
                    var post=await repository.PostEstudantesAsync(estudante);
                    if(post != null)
                    {
                        TempData["successAlert"] = true;
                        return RedirectToPage();
                    }
                    TempData["InSuccessMessage"] = "Verifique seus dados, porque não conseguimos criar sua conta";
                    return Page();
                }
                else
                {
                    TempData["successAlert"] = false;
                    TempData["InSuccessMessage"] = "Não podemos criar sua conta quando não concordo com nossos termos";
                    return Page();
                }
              
               
            }
            catch (SmtpCommandException ex)
            {
                TempData["successAlert"] = false;
                TempData["InSuccessMessage"] = ex.Message;
                return Page();
            }
            catch (Exception ex)
            {
                var r = ex.Message;
               throw;
            }
        }
    }
}
