using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;

namespace ISCED_Benguela.Pages.ViewComponents
{
    public class ChatViewComponent:ViewComponent
    {
        public ChatViewComponent()
        {
            
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
