namespace ISCED_Benguela.Modelos.DTO
{
    public class EnderecosDTO
    {
        public string? Localizacao { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
    }
    public class UpdateEnderecosDTO : EnderecosDTO
    {
        public int ID { get; set; }
    }
}