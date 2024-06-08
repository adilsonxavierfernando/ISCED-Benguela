using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Modelos.DTO;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace ISCED_Benguela.Pages.ViewComponents
{
    public class MenuPerfilViewComponent:ViewComponent
    {
        private readonly EstudanteRepository repository;
        private readonly ProfessorRepository professorRepository;

        public MenuPerfilViewComponent(EstudanteRepository Repository, ProfessorRepository professorRepository)
        {
            repository = Repository;
            this.professorRepository = professorRepository;
        }

        public IViewComponentResult Invoke(string id)
        {
            var estudantes = repository.GetEstudantesAsync();
            var professor = professorRepository.GetProfessorByIdAsync(Convert.ToInt32(id));
            var param = new ModelViewPerfilDTO { GetProfessores =professor, GetEstudantes=estudantes};
            return View(param);
        }
    }
}
