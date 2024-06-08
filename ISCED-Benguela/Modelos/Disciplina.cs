namespace ISCED_Benguela.Modelos
{
    public class Disciplina
    {
        public int ID { get; set; }
        public string NomeDisciplina { get; set; }
        public int CursoID { get; set; }
        public Cursos Curso { get; set; }
    }
}
