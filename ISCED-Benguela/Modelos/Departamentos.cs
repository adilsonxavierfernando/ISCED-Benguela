namespace ISCED_Benguela.Modelos
{
    public class Departamentos
    {
        public int ID { get; set; }
        public string NomeDepartamento { get; set; }
        public string Descricao { get; set; }
        public bool isPrincipal {  get; set; }
        public int ChefedepartamentoID { get; set; }
        public MembroDireccao? ChefeDepartamento { get; set; }
    }
}
