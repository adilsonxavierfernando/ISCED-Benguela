namespace ISCED_Benguela.Modelos.DTO
{
    public class UsuarioDTO
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataCadastro { get; set; }
        public RegisterDTO RegisterLogin { get; set; }
    }
}
