using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Modelos;
using ISCED_Benguela.Modelos.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing.Drawing2D;
using System.Security.Claims;

namespace ISCED_Benguela.Pages.Materias
{
    [Authorize(Roles ="Aluno")]
    public class AnswersModel : PageModel
    {
        private readonly MateriaRepository repository;
        public List<Comentarios> Comentarios { get; set; }
        public List<Reposta> Respostas { get; set; }
        [BindProperty]
        public ComentarioDTO ComentarioModel { get; set; }

        [BindProperty]
        public int IdComentario { get; set; }

        [BindProperty]
        public int IdEstudante { get; set; }

        public AnswersModel(MateriaRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                int idUser = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                Comentarios = await repository.GetComentariosAsync(idUser);
                return Page();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> OnGetAnswerAsync(int id,int MateriaID)
        {
            try
            {
                int idUser = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                IdEstudante = idUser;
                Comentarios = await repository.GetComentariosAsync(idUser);
                IdComentario = MateriaID;
                Respostas=await repository.GetRespostasAsync(id);
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
                var modelo = ComentarioModel;
                var post = await repository.PostComentarioAsync(modelo);
                if (post != null)
                {
                    TempData["successAlert"] = true;
                    return RedirectToPage(new { id = modelo.MateriaID });
                }
                else
                {
                    TempData["successAlert"] = false;
                    Console.WriteLine("A reação não foi enviada");
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
