using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Encapsulamento;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISCED_Benguela.Pages.Admin.Intervenientes
{
    public class EstudantesModel : PageModel
    {
        private readonly EstudanteRepository repository;
        public List<Modelos.Estudantes> lstEstudantes { get; set; }

        public EstudantesModel(EstudanteRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                this.lstEstudantes = await this.repository.GetEstudantesAsync();
                foreach (var item in lstEstudantes)
                {
                    item.Avatar.Extensao = FileConversor.ByteToString(item.Avatar.Ficheiro);
                }
                return Page();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            try
            {
                var result = await this.repository.DeleteEstudanteAsync(id);
                if (result)
                {
                    TempData["successAlert"] = true;
                    TempData["successMessage"] = "O Estudante foi deletado com sucesso";
                }
                else
                {
                    TempData["successAlert"] = false;
                    TempData["InSuccessMessage"] = "N�o foi poss�vel deletar o Estudante";
                }
                return RedirectToPage();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> OnGetApproveAsync(int id)
        {
            try
            {
                var result = await this.repository.AprovarEstudanteAsync(id);
                if (result)
                {
                    TempData["successAlert"] = true;
                    TempData["successMessage"] = "O Estudante foi Aprovado com sucesso";
                }
                else
                {
                    TempData["successAlert"] = false;
                    TempData["InSuccessMessage"] = "N�o foi poss�vel Aprovar o Estudante";
                }
                return RedirectToPage();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //bloquear estudante
        public async Task<IActionResult> OnGetBloquearAsync(int id)
        {
            try
            {
                var result = await this.repository.BloquearEstudanteAsync(id);
                if (result)
                {
                    TempData["successAlert"] = true;
                    TempData["successMessage"] = "Ac��o conclu�da com sucesso";
                }
                else
                {
                    TempData["successAlert"] = false;
                    TempData["InSuccessMessage"] = "N�o foi poss�vel concluir a ac��o";
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
