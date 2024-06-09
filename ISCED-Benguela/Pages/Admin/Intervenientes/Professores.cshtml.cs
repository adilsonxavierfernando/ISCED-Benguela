using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Encapsulamento;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISCED_Benguela.Pages.Admin.Intervenientes
{
    public class ProfessoresModel : PageModel
    {
        private readonly ProfessorRepository repository;
        public List<Modelos.Professores> lstProfessores { get; set; }
        [BindProperty]
        public bool ShowConfirmationDialog { get; set; }

        public ProfessoresModel(ProfessorRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                lstProfessores=await repository.GetProfessorAsync();
                foreach (var item in lstProfessores)
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

        //deletar Professor
        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            try
            {
                var result = await this.repository.DeleteProfessorAsync(id);
                if (result)
                {
                    TempData["successAlert"] = true;
                    TempData["successMessage"] = "O professor foi Apagado com sucesso";
                }
                else
                {
                    TempData["successAlert"] = false;
                    TempData["InSuccessMessage"] = "Não foi possível Apagar o Professor";
                }
                return RedirectToPage();
            }
            catch (Exception)
            {

                throw;
            }

        }
        //aprovar
        public async Task<IActionResult> OnGetAprovarAsync(int id)
        {
            try
            {
                var result = await this.repository.AprovarProfessorAsync(id);
                if (result)
                {
                    TempData["successAlert"] = true;
                    TempData["successMessage"] = "O professor foi Aprovado com sucesso";
                }
                else
                {
                    TempData["successAlert"] = false;
                    TempData["InSuccessMessage"] = "Não foi possível Aprovar o Professor";
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
