namespace ISCED_Benguela.Modelos
{
    public class Banner
    {
        public int ID { get; set; }
        public string Conteudo {  get; set; }
        public string Vantagens { get; set; }
        public bool Visivel { get; set; }
        public Capa Imagem { get; set; }

    }
}
