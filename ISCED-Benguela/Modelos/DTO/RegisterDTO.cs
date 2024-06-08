using ISCED_Benguela.Modelos.Enums;

namespace ISCED_Benguela.Modelos.DTO
{
    public class RegisterDTO
    {
            public string Usuario { get; set; }
            public string Password { get; set; }
            public EnumRole Role { get; set; }
    }
    public class UpdateRegisterDTO 
    {
        public int ID { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
}
