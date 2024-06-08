using System.Collections.ObjectModel;

namespace ISCED_Benguela.Modelos.DTO
{
    public class ProfessorDTO
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Nacionalidade { get; set; }
        public DateTime DataNascimento { get; set; }
        public EnderecosDTO Morada { get; set; }
        public string Bibliografia { get; set; }
        public RedesSociaisDTO? Redes { get; set; }
        public ContactosDTO Contacto { get; set; }
        public RegisterDTO RegisterLogin { get; set; }
        public int DepartamentosID { get; set; }
        public virtual int[] DisciplinasID { get; set; }
        public CapaDTO Foto { get; set; }
    }
}
