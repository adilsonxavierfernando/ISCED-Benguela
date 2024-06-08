using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISCED_Benguela.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly ProfessorRepository professor;
        private readonly DepartamentosRepository departamento;
        private readonly CursosRepository curso;
        private readonly EstudanteRepository estudante;
        private readonly MateriaRepository materia;

        public List<Modelos.Departamentos> DepartamentoList { get; set; }
        public List<Professores> ProfessoresList { get; set; }
        public List<Modelos.Cursos> CursoList { get; set; }
        public List<Modelos.Estudantes> EstudanteList { get; set; }
        public List<Modelos.Materia> MateriaList { get; set; }
        public List<Modelos.Comentarios> ComentariosList { get; set; }
        public List<Modelos.Reposta> RespostasList { get; set; }

        public IndexModel(ProfessorRepository professor, DepartamentosRepository departamento, CursosRepository curso, EstudanteRepository estudante, MateriaRepository materia)
        {
            this.professor = professor;
            this.departamento = departamento;
            this.curso = curso;
            this.estudante = estudante;
            this.materia = materia;
        }
        public async Task OnGet()
        {
            ProfessoresList = await professor.GetProfessorAsync();
            DepartamentoList = await departamento.GetDepartamentosAsync();
            CursoList = await curso.GetCursosAsync();
            EstudanteList = await estudante.GetEstudantesAsync();
            MateriaList = await materia.GetMateriaAsync();
            ComentariosList = await materia.GetComentariosAsync();
            RespostasList = await materia.GetRespostasAsync();
        }
    }
}

