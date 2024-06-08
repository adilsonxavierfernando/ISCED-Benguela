using System.Collections.ObjectModel;

namespace ISCED_Benguela.Modelos
{
    public class Materia
    {
        public int ID { get; set; }
        public string Titulo { get; set; } = null!;
        public string Conteudo { get; set; } = null!;
        public Arquivo Arquivo { get; set; }  = null!;
        public Capa Capa { get; set; } = null!;
        public DateTime DataPublicacao { get; set; }
        public int DisciplinaID { get; set; }
        public Disciplina Disciplina { get; set; } = null!;
        public int ProfessorID { get; set; }
        public Professores Professor { get; set; } = null!;
        public int DepartamentosID { get; set; }
        public Departamentos Departamentos { get; set; }= null!;
        public virtual Collection<Comentarios> Comentarios { get; set; } = null!;
        public bool Visivel { get; set; }
    }
}
