namespace ISCED_Benguela.Modelos.DTO
{
    public class DisciplinasDTO
    {
        public string NomeDisciplina { get; set; }
        public int CursoID { get; set; }
    }

    public class UpdateDisiciplinasDTO : DisciplinasDTO
    {
        public int ID { get; set; }
    }
}
