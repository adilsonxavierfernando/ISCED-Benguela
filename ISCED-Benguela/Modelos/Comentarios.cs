using System.Collections.ObjectModel;

namespace ISCED_Benguela.Modelos
{
    public class Comentarios
    {
        public int ID { get; set; }
        public int MateriaID { get; set; }
        public Materia Materia { get; set; }
        public int EstudanteID {  get; set; }
        public Estudantes Estudante { get; set;}
        public string Comentario { get; set;}
        public DateTime DataCriacao { get; set;}
        public bool Respondido { get; set;}
        public virtual Collection<Reposta> Respostas { get; set;}
    }
}
