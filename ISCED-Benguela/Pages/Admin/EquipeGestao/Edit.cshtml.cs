using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Encapsulamento;
using ISCED_Benguela.Modelos.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Protocol.Core.Types;

namespace ISCED_Benguela.Pages.Admin.EquipeGestao
{
    public class EditModel : PageModel
    {
        private readonly MembershipRepository membros;

        [BindProperty]
        public UpdateMembershipDTO modelo { get; set; }
        public EditModel(MembershipRepository membros)
        {
            this.membros = membros;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                var result = await membros.GetMemberShipAsync(id);
                if (result != null)
                {
                    result.Foto.Extensao = FileConversor.ByteToString(result.Foto.Ficheiro);
                    ViewData["membro"]=result;
                    return Page();
                }
                return RedirectToPage("./");
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
                if (modelo.Foto.Caminho is null)
                    modelo.Foto = null;
                var post = await membros.PutMemberShipAsync(modelo);
                if (post)
                {
                    TempData["successAlert"] = true;
                    TempData["successMessage"] = "Edição feita com sucesso";
                    return RedirectToPage("Index");
                }
                else
                {
                    TempData["successAlert"] = false;
                    TempData["successMessage"] = "Opa!, não foi possível avançar com seu pedido, porfavor, consulte a assistência têcnica ou tente novamente";
                    return await OnGetAsync(modelo.ID);
                }

            }
            catch (InvalidOperationException ioe)
            {
                TempData["successAlert"] = false;
                TempData["successMessage"] = ioe.Message;
                return await OnGetAsync(modelo.ID);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
