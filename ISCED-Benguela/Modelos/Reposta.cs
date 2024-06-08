namespace ISCED_Benguela.Modelos
{
    public class Reposta
    {
        public int ID { get; set; }
        public Comentarios Comentario { get; set; }
        public string Resposta { get; set; }
        public Professores Professor { get; set; }
        public int ComentarioID { get; set; }
        public int ProfessorID { get; set; }
    }
}
