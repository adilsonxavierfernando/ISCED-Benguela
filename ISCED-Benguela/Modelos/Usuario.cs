namespace ISCED_Benguela.Modelos
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataCadastro { get; set; }
        public Registro RegisterLogin { get; set; }
    }
}
