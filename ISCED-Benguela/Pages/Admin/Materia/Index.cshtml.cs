using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace ISCED_Benguela.Pages.Admin.Materia
{
    public class IndexModel : PageModel
    {
        private readonly MateriaRepository repository;

        public IndexModel(MateriaRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var result = await this.repository.GetMateriaAsync();
                if (result != null)
                {
                    var resultUnique = result.Where(x => x.ProfessorID == Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value)).ToList();
                    ViewData["Materias"] = result;
                }
          
                return Page();
            }
            catch (Exception)
            {

                throw;
            }
        }
         //eliminar Materia
        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            try
            {
                var result = await this.repository.DeleteMateriaAsync(id);
                if (result)
                {
                    TempData["successAlert"] = true;
                    TempData["successMessage"] = "A Materia foi deletada com sucesso";
                }
                else
                {
                    TempData["successAlert"] = false;
                    TempData["InSuccessMessage"] = "Não foi possível deletar a Matéria";
                }
                return RedirectToPage();

            }
            catch (Exception)
            {

                throw;
            }
        }
        //Bloquear Materia
        public async Task<IActionResult> OnGetStopAsync(int id, bool estado)
        {
            try
            {
                var result = await this.repository.StopMateriaAsync(id);
                if (result)
                {
                    TempData["successAlert"] = true;
                    TempData["successMessage"] = estado?"A Materia foi Parada com sucesso":"A Materia agora está visivel para todos";
                }
                else
                {
                    TempData["successAlert"] = false;
                    TempData["InSuccessMessage"] ="A acção não teve resultados satisfatorios";
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
