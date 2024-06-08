using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Encapsulamento;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISCED_Benguela.Pages.Admin.EquipeGestao
{
    public class IndexModel : PageModel
    {
        private readonly MembershipRepository repository;
        public List<Modelos.MembroDireccao> LstMember { get; set; }

        public IndexModel(MembershipRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                LstMember=await repository.GetMembershipAsync();
                foreach (var item in LstMember)
                {
                    item.Foto.Extensao = FileConversor.ByteToString(item.Foto.Ficheiro);
                }
                return Page();
            }
            catch (Exception)
            {

                throw;
            }
        }
        //deletar
        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            try
            {
                var result = await this.repository.DeleteMembroAsync(id);
                if (result)
                {
                    TempData["successAlert"] = true;
                    TempData["successMessage"] = "O funcionário foi deletado com sucesso";
                }
                else
                {
                    TempData["successAlert"] = false;
                    TempData["InSuccessMessage"] = "Não foi possível deletar o funcionário";
                }
                return RedirectToPage();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
