namespace ISCED_Benguela.Modelos.DTO
{
    public class CursosDTO
    {
        public string NomeCurso { get; set; }
        public int FormacaoID { get; set; }
        public int DepartamentoID { get; set; }
        public string? Descricao { get; set; }
        public bool Ativo { get; set; }
        public CapaDTO? CapaCurso { get; set; }
        public ArquivoDTO? ArquivoCurso { get; set; }
    }
    public class UpdateCursosDTO
    {
        public int ID { get; set; }
        public string NomeCurso { get; set; }
        public int FormacaoID { get; set; }
        public int DepartamentoID { get; set; }
        public string? Descricao { get; set; }
        public bool Ativo { get; set; }
        public UpdateCapaDTO CapaCurso { get; set; } = null!;
        public UpdateArquivoDTO ArquivoCurso { get; set; } = null!;
    }
}