using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Encapsulamento;
using ISCED_Benguela.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISCED_Benguela.Pages.Formacao
{
    public class CursoDetalheModel : PageModel
    {
        private readonly CursosRepository repository;
         public Modelos.Cursos CursoModel { get; set; }
        public CursoDetalheModel(CursosRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
			try
			{
               CursoModel=await repository.GetCursosAsync(id);
                CursoModel.ArquivoCurso.Extensao = FileConversor.ByteToString(CursoModel.ArquivoCurso.Ficheiro);
                return Page();
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
