using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Encapsulamento;
using ISCED_Benguela.Modelos;
using ISCED_Benguela.Modelos.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;

namespace ISCED_Benguela.Pages.Admin.Materia
{
    public class EditMateriaModel : PageModel
    {
        private readonly MateriaRepository materiaRepository;
        private readonly DepartamentosRepository departamentosRepository;
        private readonly DisciplinaRepository disciplinaRepository;

        public List<Modelos.Departamentos> lstDepartamento { get; set; }
        public List<Modelos.Disciplina> lstDisciplinas { get; set; }

        [BindProperty]
        public UpdateMateriaDTO model { get; set; }

        public EditMateriaModel(MateriaRepository materiaRepository, DepartamentosRepository departamentosRepository, DisciplinaRepository disciplinaRepository)
        {
            this.materiaRepository = materiaRepository;
            this.departamentosRepository = departamentosRepository;
            this.disciplinaRepository = disciplinaRepository;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                lstDisciplinas=await disciplinaRepository.GetDisciplinaAsync();
                lstDepartamento = await departamentosRepository.GetDepartamentosAsync();
                var result= await materiaRepository.GetMateriaAsync(id);
                var item = result;
                item.Capa.Extensao = FileConversor.ByteToString(item.Capa.Ficheiro);
                if (result is not null)
                {
                    ViewData["materia"] = item;
                }
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
                if (model.Capa.Caminho is null)
                    model.Capa = null;

                if (model.Arquivo.Caminho is null)
                    model.Arquivo = null;
                var result = await materiaRepository.PutMateria(model);
                if (result)
                {
                    TempData["successAlert"] = true;
                    TempData["successMessage"] = "A Matéria Foi Atualizada com sucesso.";
                    return RedirectToPage("/Admin/Materia/Index");
                }
                else
                {
                    TempData["successAlert"] = false;
                    TempData["successMessage"] = "Por algum Motivo, sua matéria não foi atualizada ):";
                    return await OnGetAsync(model.ID);
                }
             
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
