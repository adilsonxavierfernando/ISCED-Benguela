﻿using ISCED_Benguela.Modelos.Enums;

namespace ISCED_Benguela.Modelos
{
    public class Registro
    {
        public int ID { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public EnumRole Role { get; set; }
    }
}
