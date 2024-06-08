namespace ISCED_Benguela.Modelos.DTO
{
    public class DepartamentoDTO
    {
        public string NomeDepartamento { get; set; }
        public string Descricao { get; set; }
        public bool isPrincipal { get; set; }
        public int ChefedepartamentoID { get; set; }
    }

    public class UpdateDepartamentoDTO : DepartamentoDTO 
    {
        public int ID { get; set; }
    }
}
