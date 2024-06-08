using System.Collections.ObjectModel;

namespace ISCED_Benguela.Modelos.DTO
{
    public class MateriaDTO
    {
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public ArquivoDTO Arquivo { get; set; }
        public CapaDTO Capa { get; set; }
        public int DisciplinaID { get; set; }
        public int ProfessorID { get; set; }
        public int DepartamentosID { get; set; }
    }
    public class UpdateMateriaDTO
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public UpdateArquivoDTO Arquivo { get; set; }
        public UpdateCapaDTO Capa { get; set; }
        public int DisciplinaID { get; set; }
        public int ProfessorID { get; set; }
        public int DepartamentosID { get; set; }

    }
}
