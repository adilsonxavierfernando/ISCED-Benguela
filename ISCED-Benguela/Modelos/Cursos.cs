using ISCED_Benguela.Modelos.DTO;

namespace ISCED_Benguela.Modelos
{
    public class Cursos
    {
        public int ID { get; set; }
        public string NomeCurso { get; set; }
        public string? Descricao { get; set; }
        public int FormacaoID { get; set; }
        public Formacao Formacao {get;set;}
        public int DepartamentoID { get; set; }
        public Departamentos Departamento {get;set; }
        public Capa? CapaCurso { get; set; }
        public Arquivo? ArquivoCurso { get; set; }
        public bool Ativo { get; set; }
    }
}
