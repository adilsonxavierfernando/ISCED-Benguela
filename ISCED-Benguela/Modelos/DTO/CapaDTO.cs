namespace ISCED_Benguela.Modelos.DTO
{
    public class CapaDTO
    {
        public IFormFile Caminho { get; set; }
        public byte[]? Ficheiro { get; set; }
        public string? Extensao { get; set; }
    }
    public class UpdateCapaDTO : CapaDTO
    {
       public int ID { get; set; }
    }
}
