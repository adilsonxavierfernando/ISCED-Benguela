using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Modelos.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISCED_Benguela.Pages.Admin.Departamentos
{
    public class EditModel : PageModel
    {
        private readonly DepartamentosRepository repository;
        private readonly MembershipRepository membership;
        [BindProperty]
        public UpdateDepartamentoDTO modelo { get;set; }
        public EditModel(DepartamentosRepository repository, MembershipRepository membership)
        {
            this.repository = repository;
            this.membership = membership;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                ViewData["membros"] = await membership.GetMembershipAsync();
                ViewData["departamento"]=await repository.GetDepartamentoAsync(id);
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
                if (!ModelState.IsValid) { return Page(); }
                var post = await repository.PutDepartamentoAsync(modelo);
                if (post)
                {
                    TempData["successAlert"] = true;
                    TempData["successMessage"] = "Edição feita com sucesso";
                    return RedirectToPage("/Admin/Departamentos/Index");
                }
                else
                {
                    TempData["successAlert"] = false;
                    TempData["successMessage"] = "Opa!, não foi possível avançar com seu pedido, porfavor, consulte a assistência têcnica ou tente novamente";
                    return Page();
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
