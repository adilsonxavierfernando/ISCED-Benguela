using ISCED_Benguela.Modelos.DTO;
using System.Collections.ObjectModel;

namespace ISCED_Benguela.Modelos
{
    public class Professores
    {
        public int ID { get;set; }
        public string Nome { get;set; }
        public string Sobrenome {  get;set; }
        public DateTime DataNascimento { get;set; }
        public Enderecos Morada { get;set; }
        public string Bibliografia { get;set; }
        public RedesSociais? Redes { get;set; }
        public Contactos Contacto { get; set; }
        public Registro RegisterLogin { get;set; }
        public int DepartamentosID { get;set; }
        public Departamentos Departamentos { get;set; }
        //public virtual Collection<Disciplina> Disciplinas { get;set; }
        public Capa Foto { get;set; }
        public bool Aprovado { get; set; }
        public bool Bloqueado { get; set; }
        public bool Ativo { get; set; }
    }
}
