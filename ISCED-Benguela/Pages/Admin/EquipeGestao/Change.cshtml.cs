using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Modelos;
using ISCED_Benguela.Modelos.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISCED_Benguela.Pages.Admin.EquipeGestao
{
    public class ChangeModel : PageModel
    {
        private readonly MembershipRepository repository;

        [BindProperty]
        public MembershipDTO memberDTO { get; set; }
        public ChangeModel(MembershipRepository repository)
        {
            this.repository = repository;
        }
        public async  Task<IActionResult> OnGetAsync()
        {
            try
            {
                return Page();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //criar
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                var post = await repository.PostMembrosAsync(memberDTO);
                if (post != null)
                {
                    TempData["successAlert"] = true;
                    TempData["successMessage"] = "Novo membro da Direcção, adicionado";
                    return RedirectToPage("/Admin/EquipeGestao/Index");
                }
                else
                {
                    TempData["successAlert"] = false;
                    TempData["successMessage"] = "Opha! Não foi possível avançar com seu pedido, tente novamente ou consulte a assistência técnica";
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
