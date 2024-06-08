namespace ISCED_Benguela.Modelos.DTO
{
    public class MembershipDTO
    {
        public string NomeFuncionario { get; set; }
        public string Cargo { get; set; }
        public CapaDTO Foto { get; set; }
        public RedesSociaisDTO RedesSociais { get; set; }
    }
    public class UpdateMembershipDTO
    {
        public int ID { get; set; }
        public string NomeFuncionario { get; set; }
        public string Cargo { get; set; }
        public UpdateCapaDTO Foto { get; set; }
        public UpdateRedesSociaisDTO RedesSociais { get; set; }
    }
}
