using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Encapsulamento;
using ISCED_Benguela.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISCED_Benguela.Pages
{
    public class aboutModel : PageModel
    {
        private readonly MembershipRepository repository;
        public List<MembroDireccao> LstMember { get; set; }

        public aboutModel(MembershipRepository professor)
        {
            this.repository = professor;
        }
        public async Task<IActionResult> OnGet()
        {
            try
            {
                LstMember = (await repository.GetMembershipAsync()).OrderBy(x => x.Cargo.ToLower().Contains("Presidente".ToLower())?0:1).ThenBy(x => x.NomeFuncionario).ToList();
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
    }
}
