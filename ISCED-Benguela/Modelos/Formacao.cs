using System.Collections.ObjectModel;

namespace ISCED_Benguela.Modelos
{
    public class Formacao
    {
        public int ID { get; set; }
        public string NomeFormacao { get; set; }
        public bool Ativo { get; set; }
        public virtual Collection<Cursos> Cursos { get; set; }  
    }
}