using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Encapsulamento;
using ISCED_Benguela.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ISCED_Benguela.Pages.Membership
{
    public class IndexModel : PageModel
    {
        private readonly ProfessorRepository professorRepository;
        private readonly MembershipRepository membershipRepository;

        public List<Professores>Professores { get; set; }  
        public List<MembroDireccao>Membros { get; set; }
        public string Area { get; set; }
        public IndexModel(ProfessorRepository professorRepository, MembershipRepository membershipRepository)
        {
            this.professorRepository = professorRepository;
            this.membershipRepository = membershipRepository;
        }
        public async Task<IActionResult> OnGet(string zona)
        {
			try
			{
                Area = zona;
                Professores = await professorRepository.GetProfessorAsync();
                Membros=await membershipRepository.GetMembershipAsync();
                foreach (var item in Professores)
                {
                    item.Foto.Extensao = FileConversor.ByteToString(item.Foto.Ficheiro);
                }

                foreach (var item in Membros)
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
