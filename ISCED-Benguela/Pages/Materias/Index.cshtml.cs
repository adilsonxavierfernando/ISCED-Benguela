using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Encapsulamento;
using ISCED_Benguela.Modelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;

namespace ISCED_Benguela.Pages.Materias
{
    [Authorize]
    public class IndexModel : PageModel
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
        public List<Modelos.Estudantes> EstudanteList { get; set; }
        public List<Materia> MateriaList { get; set; }
        public IndexModel(ILogger<IndexModel> logger, ProfessorRepository professor, DepartamentosRepository departamento, CursosRepository curso, EstudanteRepository estudante, MateriaRepository materia)
        {
            _logger = logger;
            this.professor = professor;
            this.departamento = departamento;
            this.curso = curso;
            this.estudante = estudante;
            this.materia = materia;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            ProfessoresList = await professor.GetProfessorAsync();
            DepartamentoList = await departamento.GetDepartamentosAsync();
            CursoList = await curso.GetCursosAsync();
            EstudanteList = await estudante.GetEstudantesAsync();
            MateriaList = (await materia.GetMateriaByDepartamentoAsync(id)).Where(x=>x.Visivel).ToList();

            foreach (var item in ProfessoresList)
            {
                item.Foto.Extensao = FileConversor.ByteToString(item.Foto.Ficheiro);
            }

            foreach (var item in MateriaList)
            {
                item.Capa.Extensao = FileConversor.ByteToString(item.Capa.Ficheiro);
                if (item.Professor.Foto != null)
                    item.Professor.Foto.Extensao = FileConversor.ByteToString(item.Professor.Foto.Ficheiro);
                item.Conteudo = RemoveHtmlTags(item.Conteudo);
            }

            return Page();

        }

        public static string RemoveHtmlTags(string html)
        {
            return Regex.Replace(html, "<.*?>", string.Empty);
        }

    }
}
