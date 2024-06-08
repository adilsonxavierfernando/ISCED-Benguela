namespace ISCED_Benguela.Modelos.DTO
{
    public class RedesSociaisDTO
    {
        public string? Facebook { get; set; }
        public string? Linkedin { get; set; }
        public string? Instagram { get; set; }
        public string? Youtube { get; set; }
    }
    public class UpdateRedesSociaisDTO : RedesSociaisDTO
    {
       public int ID { get; set; }
    }
}