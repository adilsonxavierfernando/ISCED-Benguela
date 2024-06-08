using System.Collections.ObjectModel;

namespace ISCED_Benguela.Modelos
{
    public class InfoSite
    {
        public int ID { get; set; }

        public int ContactoID { get; set; }
        public Contactos Contacto { get; set; }
        public int EnderecoID { get; set; }
        public Enderecos Endereco {  get; set; }
        public int RedesID { get; set; }
        public RedesSociais Redes { get; set; }
        public string Geomap { get;set; }
    }
}
