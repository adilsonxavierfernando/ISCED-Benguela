using System.ComponentModel.DataAnnotations;

namespace ISCED_Benguela.Modelos.DTO
{
    public class ContactosDTO
    {
        [StringLength(13, MinimumLength = 9, ErrorMessage = "O Telefone n está correcto.")]
        public string Telefone { get; set; }
        public string? Celular { get; set; }
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }
    }
}