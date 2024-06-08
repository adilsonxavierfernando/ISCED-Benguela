namespace ISCED_Benguela.Modelos.DTO
{
    public class ModelViewPerfilDTO
    {
        public Task<List<Estudantes>> GetEstudantes { get; set; } = null!;
        public Task<Professores> GetProfessores { get; set; } = null!;
    }
}
