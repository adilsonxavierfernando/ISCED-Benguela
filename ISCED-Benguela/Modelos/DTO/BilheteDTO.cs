namespace ISCED_Benguela.Modelos.DTO
{
    public class BilheteDTO
    {
        private DateTime _data;

        public string Numero {  get; set; }
        public DateTime Validade {
            get => _data;
            set
            {
                // Adicione sua lógica de validação aqui
                if (value > DateTime.UtcNow)
                {
                    _data = value;
                }
                else
                {
                    throw new ArgumentException("Data de validade inválida.");
                }
            }
        }
    }
}