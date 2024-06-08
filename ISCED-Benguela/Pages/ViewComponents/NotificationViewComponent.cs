using ISCED_Benguela.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ISCED_Benguela.Pages.ViewComponents
{
    public class NotificationViewComponent:ViewComponent
    {
        private readonly MateriaRepository repository;

        public NotificationViewComponent(MateriaRepository repository)
        {
            this.repository = repository;
        }
        public  IViewComponentResult Invoke(string id)
        {
            var result = repository.GetComentariosByInstrutorAsync(Convert.ToInt32(id));
            return View(result);
        }

    }
}
