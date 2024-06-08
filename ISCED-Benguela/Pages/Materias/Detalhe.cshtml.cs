using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Encapsulamento;
using ISCED_Benguela.Modelos;
using ISCED_Benguela.Modelos.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol.Core.Types;
using Slugify;

namespace ISCED_Benguela.Pages.Materias
{
    [Authorize]
    public class DetalheModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ProfessorRepository professor;
        private readonly DepartamentosRepository departamento;
        private readonly CursosRepository curso;
        private readonly EstudanteRepository estudante;
        private readonly MateriaRepository materia;

        public List<Departamentos> DepartamentoList { get; set; }
        public List<Professores> ProfessoresList { get; set; }
        public List<Modelos.Cursos> CursoList { get; set; }
        public Materia MateriaList { get; set; }
        [BindProperty]
        public ComentarioDTO Comentario { get; set; }
        public string TituloDownloadFile { get; set; }
        public DetalheModel(ILogger<IndexModel> logger, ProfessorRepository professor, DepartamentosRepository departamento, CursosRepository curso, EstudanteRepository estudante, MateriaRepository materia)
        {
            _logger = logger;
            this.professor = professor;
            this.departamento = departamento;
            this.curso = curso;
            this.estudante = estudante;
            this.materia = materia;
        }
        //public async Task<IActionResult> OnGetAsync()
        //{
        //    return BadRequest("Está caindo aqui");
        //}
        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                //return BadRequest("Está caindo aqui, e o id é" + id);
                ProfessoresList = await professor.GetProfessorAsync();
                DepartamentoList = await departamento.GetDepartamentosAsync();
                CursoList = await curso.GetCursosAsync();
                MateriaList = await materia.GetMateriaAsync(id);

                foreach (var item in ProfessoresList)
                {
                    item.Foto.Extensao = FileConversor.ByteToString(item.Foto.Ficheiro);
                }

                MateriaList.Capa.Extensao = FileConversor.ByteToString(MateriaList.Capa.Ficheiro);
                if (MateriaList.Professor.Foto != null)
                    MateriaList.Professor.Foto.Extensao = FileConversor.ByteToString(MateriaList.Professor.Foto.Ficheiro);
                if (MateriaList.Arquivo.Ficheiro != null)
                    MateriaList.Arquivo.Extensao = FileConversor.ByteToPdfString(MateriaList.Arquivo.Ficheiro);
                TituloDownloadFile= new SlugHelper().GenerateSlug(MateriaList.Titulo)+$"_Prof_{MateriaList.Professor.Nome}.pdf";
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
                var modelo = Comentario;
                var post = await materia.PostComentarioAsync(modelo);
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
