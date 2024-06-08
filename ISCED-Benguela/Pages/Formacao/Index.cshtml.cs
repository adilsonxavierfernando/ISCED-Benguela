using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Encapsulamento;
using ISCED_Benguela.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.ObjectModel;

namespace ISCED_Benguela.Pages.Cursos
{
    public class IndexModel : PageModel
    {
        private readonly CursosRepository repository;
        public List<Modelos.Cursos> lstCursos { get; set; }
        public Modelos.Formacao modelFormacao { get; set; }
        public string DepartamentoActual { get; set; }

        public IndexModel(CursosRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> OnGet(int id)
        {
			try
			{
              lstCursos=await repository.GetCursosByFormacaoAsync(id);
                modelFormacao=await repository.GetFormacaoByIdAsync(id);
                foreach (var item in lstCursos)
                {
                    item.CapaCurso.Extensao = FileConversor.ByteToString(item.CapaCurso.Ficheiro);
                    item.ArquivoCurso.Extensao = FileConversor.ByteToString(item.ArquivoCurso.Ficheiro);
                }
                return Page();
			}
			catch (Exception)
			{

				throw;
			}
        }
         //formação por departamento
        public async Task<IActionResult> OnGetDepartamento(int id)
        {
            try
            {
                lstCursos = await repository.GetCursosByDepartamentoAsync(id);
                if (lstCursos != null)
                {
                    foreach (var item in lstCursos)
                    {
                        DepartamentoActual = item.Departamento.NomeDepartamento;
                        item.CapaCurso.Extensao = FileConversor.ByteToString(item.CapaCurso.Ficheiro);
                        item.ArquivoCurso.Extensao = FileConversor.ByteToString(item.ArquivoCurso.Ficheiro);
                    }
                    modelFormacao = await repository.GetFormacaoByIdAsync(id);
                }
             
               
                return Page();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
