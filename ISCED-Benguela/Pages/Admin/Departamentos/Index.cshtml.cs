using ISCED_Benguela.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISCED_Benguela.Pages.Admin.Departamentos
{
    public class IndexModel : PageModel
    {
        private readonly DepartamentosRepository repository;
        public List<Modelos.Departamentos> GetDepartamentos { get; set; }

        public IndexModel(DepartamentosRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
               GetDepartamentos=await repository.GetDepartamentosAsync();
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
                var result = await this.repository.DeletetDepartamentosAsync(id);
                if (result)
                {
                    TempData["successAlert"] = true;
                    TempData["successMessage"] = "O Departamento foi deletado com sucesso";
                }
                else
                {
                    TempData["successAlert"] = false;
                    TempData["InSuccessMessage"] = "Não foi possível deletar o Departamento";
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
