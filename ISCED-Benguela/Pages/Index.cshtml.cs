using ISCED_Benguela.Data.Repository;
using ISCED_Benguela.Encapsulamento;
using ISCED_Benguela.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace ISCED_Benguela.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly ProfessorRepository professor;
    private readonly DepartamentosRepository departamento;
    private readonly CursosRepository curso;
    private readonly EstudanteRepository estudante;
    private readonly MateriaRepository materia;

    public List<Departamentos> DepartamentoList { get; set; }
    public List<Professores> ProfessoresList { get; set; }
    public List<Modelos.Cursos> CursoList { get; set; }
    public List<Modelos.Estudantes> EstudanteList { get; set; }
    public List<Materia> MateriaList { get; set; }
    public List<Modelos.Formacao> FormacaoList { get; set; }

    public IndexModel(ILogger<IndexModel> logger, ProfessorRepository professor, DepartamentosRepository departamento, CursosRepository curso, EstudanteRepository estudante, MateriaRepository materia)
    {
        _logger = logger;
        this.professor = professor;
        this.departamento = departamento;
        this.curso = curso;
        this.estudante = estudante;
        this.materia = materia;
    }

    public async  Task OnGetAsync()
    {
        ProfessoresList = (await professor.GetProfessorAsync()).Where(x=>x.Aprovado && !x.Bloqueado).ToList();
        DepartamentoList = await departamento.GetDepartamentosAsync();
        CursoList = await curso.GetCursosAsync();
        EstudanteList = await estudante.GetEstudantesAsync();
        MateriaList = (await materia.GetMateriaAsync()).Where(x=>x.Visivel).ToList();
        FormacaoList = await curso.GetFormacaoAsync();

        int idUser = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        var e = await estudante.GetEstudantesByAsync(idUser);
        if (e is not null)
        {
            MateriaList = (await materia.GetMateriaAsync()).Where(x => x.Visivel && x.DepartamentosID == e.Curso.DepartamentoID).ToList();
            foreach (var item in DepartamentoList)
            {
                item.isPrincipal = false;
                if (item.ID == e.Curso.DepartamentoID)
                    item.isPrincipal = true;
            }

            ProfessoresList = ProfessoresList.Where(x => x.DepartamentosID == e.Curso.DepartamentoID).ToList();
        }
        else
        {
            var p = await professor.GetProfessorByIdAsync(idUser);
            if (p is not null)
            {
                MateriaList = (await materia.GetMateriaAsync()).Where(x => x.Visivel && x.DepartamentosID == p.DepartamentosID).ToList();
                foreach (var item in DepartamentoList)
                {
                    item.isPrincipal = false;
                    if (item.ID == p.DepartamentosID)
                        item.isPrincipal = true;
                }
                ProfessoresList = ProfessoresList.Where(x => x.DepartamentosID == p.DepartamentosID).ToList();
            }

        }

        foreach (var item in ProfessoresList)
        {
            item.Foto.Extensao = FileConversor.ByteToString(item.Foto.Ficheiro!);
        }

        foreach (var item in MateriaList)
        {
            item.Capa.Extensao = FileConversor.ByteToString(item.Capa.Ficheiro!);
            if(item.Professor.Foto!=null)
                item.Professor.Foto.Extensao = FileConversor.ByteToString(item.Professor.Foto.Ficheiro!);
            item.Conteudo=RemoveHtmlTags(item.Conteudo);
        }


    }
    public static string RemoveHtmlTags(string html)
    {
        return Regex.Replace(html, "<.*?>", string.Empty);
    }


    public IActionResult OnGetFile(string ficheiro, string extensao)
    {
        byte[] bytesFicheiro = Convert.FromBase64String(ficheiro);

        return Conversores.GetFile(bytesFicheiro, extensao);
    }
}
