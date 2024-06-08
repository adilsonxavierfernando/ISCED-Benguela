namespace ISCED_Benguela.Modelos
{
    public class Estudantes
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime dataNascimento { get; set; }
        public string Nacionalidade { get; set; }
        public Contactos Contactos { get; set; }
        public int CursosID { get; set; }
        public bool Aprovado { get; set; }
        public bool Bloqueado { get; set; }
        public Cursos Curso { get; set; }
        public Registro RegisterLogin { get; set; }
        public bool Ativo { get; set; }
        public Capa Avatar { get; set; }

    }
}
