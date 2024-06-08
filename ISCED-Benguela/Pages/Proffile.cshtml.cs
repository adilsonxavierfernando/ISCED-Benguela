using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Encapsulamento;
using ISCED_Benguela.Modelos.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace ISCED_Benguela.Pages
{
    public class ProffileModel : PageModel
    {
        private readonly EstudanteRepository repository;
        [BindProperty]
        public UpdateEstudanteDTO modelo { get; set; }

        public ProffileModel(EstudanteRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult>  OnGetAsync()
        {
            try
            {
                int id = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
                var result = await repository.GetEstudantesByAsync(id);
                result.Avatar.Extensao =FileConversor.ByteToString(result.Avatar.Ficheiro);
                ViewData["perfil"]=result;
                return Page();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (modelo.Avatar.Caminho is null)
                    modelo.Avatar = null;
                var post = await repository.PutEstudante(modelo);
                
                if (post)
                {
                    TempData["successAlert"] = true;
                    TempData["successMessage"] = "Edição feita com sucesso";
                    return await OnGetAsync();
                }
                else
                {
                    TempData["successAlert"] = false;
                    TempData["successMessage"] = "Opa!, não foi possível avançar com seu pedido, porfavor, consulte a assistência têcnica ou tente novamente";
                    return await OnGetAsync();
                }

            }
            catch (InvalidOperationException ioe)
            {
                TempData["successAlert"] = false;
                TempData["successMessage"] = ioe.Message;
                return await OnGetAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
