using System.ComponentModel.DataAnnotations;

namespace ISCED_Benguela.Modelos.DTO
{
    public class EstudanteDTO
    {
        private DateTime _dataNascimento;
        private int _curso;

        [Required(ErrorMessage ="O campo nome é obrigatório")]
       
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime dataNascimento 
        {
            get => _dataNascimento;
            set
            {
                // Adicione sua lógica de validação aqui
                if (value <= DateTime.UtcNow.AddYears(-18))
                {
                    _dataNascimento = value;
                }
                else
                {
                    throw new ArgumentException("A data de Nascimento não é válida.");
                }
            }
        }

        public string Nacionalidade { get; set; }
        public ContactosDTO Contactos { get; set; }
        public EnderecosDTO Morada { get; set; }
        public BilheteDTO Bilhete { get; set; }
        public int CursosID
        {
            get=> _curso; 
            set
            {
                if (value>0)
                {
                    _curso= value;
                }
                else
                {
                    throw new ValidationException("Deve selecionar um curso");
                }
            }
        }
        public RegisterDTO RegisterLogin { get; set; }
        public CapaDTO Avatar { get; set; }

    }

    public class UpdateEstudanteDTO
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public UpdateRegisterDTO RegisterLogin { get; set; }
        public UpdateCapaDTO Avatar { get; set; }
    }
}
