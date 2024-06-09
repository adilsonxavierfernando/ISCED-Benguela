namespace ISCED_Benguela.Modelos
{
    public class MembroDireccao
    {
        public int ID { get; set; }
        public string NomeFuncionario { get; set; }
        public string Cargo { get; set; }
        public int FotoID { get; set; }
        public Capa Foto { get; set; }
        public int RedesSociaisID{get;set;}
        public RedesSociais RedesSociais { get; set; }
    }
}