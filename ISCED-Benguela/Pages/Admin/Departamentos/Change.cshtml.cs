using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Modelos;
using ISCED_Benguela.Modelos.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISCED_Benguela.Pages.Admin.Departamentos
{
    public class ChangeModel : PageModel
    {
        private readonly DepartamentosRepository repository;
        private readonly MembershipRepository membership;

       

        [BindProperty]
        public DepartamentoDTO depDTO { get; set; }
        public List<MembroDireccao> LstChefesDepartamento { get; set; }
        public ChangeModel(DepartamentosRepository repository, MembershipRepository membership)
        {
            this.repository = repository;
            this.membership = membership;
        }
        public async Task<IActionResult>  OnGetAsync()
        {
            try
            {
                LstChefesDepartamento=await membership.GetMembershipAsync();
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
                var post = await repository.PostDepartamentoAsync(depDTO);
                if (post != null)
                {
                    TempData["successAlert"] = true;
                    TempData["successMessage"] = "Mais um departamento publicado com sucesso";
                    return RedirectToPage("/Admin/Departamentos/Index");
                }
                else
                {
                    TempData["successAlert"] = false;
                    TempData["successMessage"] = "Opa!, não foi possível avançar com seu pedido, porfavor, consulte a assistência têcnica ou tente novamente";
                    return Page();
                }
            
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
