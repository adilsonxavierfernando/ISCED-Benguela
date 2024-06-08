namespace ISCED_Benguela.Modelos.DTO
{
    public class ArquivoDTO
    {
        public IFormFile Caminho { get; set; }
        public byte[] Ficheiro { get; set; }
        public string Extensao { get; set; }
    }
    public class UpdateArquivoDTO : ArquivoDTO
    {
        public int ID { get; set; }
    }
}
