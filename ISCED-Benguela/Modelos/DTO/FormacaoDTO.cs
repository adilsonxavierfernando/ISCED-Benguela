namespace ISCED_Benguela.Modelos.DTO
{
    public class FormacaoDTO
    {
        public string NomeFormacao { get; set; }
    }
    public class UpdateFormacaoID:FormacaoDTO
    {
        public int ID { get; set; }
    }
}
