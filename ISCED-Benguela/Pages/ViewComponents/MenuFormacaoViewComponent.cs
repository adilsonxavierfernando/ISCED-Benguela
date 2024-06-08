using ISCED_Benguela.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace ISCED_Benguela.Pages.ViewComponents
{
    public class MenuFormacaoViewComponent:ViewComponent
    {
        private readonly CursosRepository repository;

        public MenuFormacaoViewComponent(CursosRepository Repository)
        {
            repository = Repository;
        }

        public IViewComponentResult Invoke()
        {
            var formacao = repository.GetFormacaoAsync();
            return View(formacao);
        }
    }
}
