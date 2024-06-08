using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Modelos;
using ISCED_Benguela.Modelos.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Drawing.Drawing2D;
using System.Security.Claims;

namespace ISCED_Benguela.Pages.Admin.Materia.Respostas
{
    public class IndexModel : PageModel
    {
        private readonly MateriaRepository repository;
         public List<Comentarios> ComentariosLst { get; set; }
        [BindProperty]
        public RespostaDTO ModeloDTO { get; set; }
        private int IdEstudante { get; set; }
        public IndexModel(MateriaRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                var result = await repository.GetComentariosAsync(id);
                int idProf = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

                if (result != null)
                {
                    this.IdEstudante = id;
                    result = result.Where(x => x.Materia.ProfessorID == idProf && x.Respondido==false).ToList();
                    ComentariosLst = result;
                }
                   
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
                var post = await repository.PostRespostaAsync(ModeloDTO);
                if (post != null)
                {
                    TempData["successAlert"] = true;
                    return RedirectToPage(new { id = this.IdEstudante });
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
