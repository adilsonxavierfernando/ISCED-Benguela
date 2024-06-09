using AutoMapper;
using ISCED_Benguela.Modelos;
using ISCED_Benguela.Modelos.DTO;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace ISCED_Benguela.Data.AutoMapper
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<EstudanteDTO, Estudantes>();
            CreateMap<ProfessorDTO, Professores>();
            CreateMap<ContactosDTO, Contactos>();
            CreateMap<EnderecosDTO, Enderecos>();
            CreateMap<CursosDTO, Cursos>();
            CreateMap<RegisterDTO, Modelos.Registro>();
            CreateMap<BilheteDTO, Bilhete>();
            CreateMap<ArquivoDTO, Arquivo>();
            CreateMap<CapaDTO, Capa>();
            CreateMap<MateriaDTO, Materia>();
            CreateMap<DepartamentoDTO, Departamentos>();
            CreateMap<DisciplinasDTO, Disciplina>();
            CreateMap<RedesSociaisDTO, RedesSociais>();
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<ComentarioDTO, Comentarios>();
            CreateMap<MembershipDTO, MembroDireccao>();
            CreateMap<FeedbackDTO, Feedbacks>();
            CreateMap<FormacaoDTO, Formacao>();
            CreateMap<RespostaDTO, Reposta>();
            CreateMap<InfoSiteDTO, InfoSite>();


        }
    }
}
