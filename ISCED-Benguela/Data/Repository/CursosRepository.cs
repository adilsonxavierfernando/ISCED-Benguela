using AutoMapper;
using ISCED_Benguela.Data.Context;
using ISCED_Benguela.Modelos.DTO;
using ISCED_Benguela.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ISCED_Benguela.Data.Repository
{
    public class CursosRepository
    {
        private readonly IMapper mapper;
        private readonly IscedDbContext context;

        public CursosRepository(IMapper mapper, IscedDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public async Task<Cursos> PostCursoAsync(CursosDTO disci)
        {

            try
            {
                disci.CapaCurso.Ficheiro = await Conversores.Conversores_for_bytesAsync(disci.CapaCurso.Caminho);
                disci.CapaCurso.Extensao = "PNG";

                disci.ArquivoCurso.Ficheiro = await Conversores.Conversores_for_bytesAsync(disci.ArquivoCurso.Caminho);
                disci.ArquivoCurso.Extensao = "pdf";
                var modelo = mapper.Map<Cursos>(disci);
                await context.Cursos.AddAsync(modelo);
                await context.SaveChangesAsync();
                return modelo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Cursos> GetCursosAsync(int idCurso)
        {

            try
            {
                var result = await context.Cursos
                    .Include(x=>x.CapaCurso)
                    .Include(x=>x.ArquivoCurso)
                     .Include(x => x.Formacao)
                    .Include(x => x.Departamento).ThenInclude(x=>x.ChefeDepartamento).ThenInclude(x=>x.Foto)
                    .FirstOrDefaultAsync(x => x.ID == idCurso);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Cursos>> GetCursosByFormacaoAsync(int idFormacao)
        {

            try
            {
                var result = await context.Cursos
                    .Include(x => x.CapaCurso)
                    .Include(x => x.ArquivoCurso)
                     .Include(x => x.Formacao)
                    .Include(x => x.Departamento).ThenInclude(x => x.ChefeDepartamento).ThenInclude(x => x.Foto)
                    .Where(x => x.Formacao.ID == idFormacao).ToListAsync();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Cursos>> GetCursosByDepartamentoAsync(int idDepartamento)
        {

            try
            {
                var result = await context.Cursos
                    .Include(x => x.CapaCurso)
                    .Include(x => x.ArquivoCurso)
                     .Include(x => x.Formacao)
                    .Include(x => x.Departamento).ThenInclude(x => x.ChefeDepartamento).ThenInclude(x => x.Foto)
                    .Where(x => x.DepartamentoID == idDepartamento).ToListAsync();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Cursos>> GetCursosAsync()
        {

            try
            {
                var result = await context.Cursos
                     .Include(x => x.CapaCurso)
                    .Include(x => x.ArquivoCurso)
                     .Include(x => x.Formacao)
                    .Include(x => x.Departamento).ThenInclude(x => x.ChefeDepartamento).ThenInclude(x => x.Foto)
                    .ToListAsync();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //editar curso
        public async Task<bool> PutCursoAsync(UpdateCursosDTO update)
        {
            try
            {
                var result = await context.Cursos.FirstOrDefaultAsync(x => x.ID == update.ID);
                if(result is not null)
                {
                    result.NomeCurso = update.NomeCurso;
                    result.DepartamentoID = update.DepartamentoID;
                    result.FormacaoID= update.FormacaoID;
                    result.Descricao= update.Descricao;
                    result.Ativo= update.Ativo;
                    if (update.CapaCurso is not null)
                        await atualizarFoto(update.CapaCurso);


                    if (update.ArquivoCurso is not null)
                        await atualizarArquivo(update.ArquivoCurso);

                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task atualizarArquivo(UpdateArquivoDTO update)
        {
            try
            {
                var result = await context.Arquivos.FirstOrDefaultAsync(x => x.ID == update.ID);
                if (result is not null)
                {
                    result.Ficheiro = await Conversores.Conversores_for_bytesAsync(update.Caminho);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task atualizarFoto(UpdateCapaDTO update)
        {
            try
            {
                var result = await context.Capas.FirstOrDefaultAsync(x => x.ID == update.ID);
                if (result is not null)
                {
                    result.Ficheiro = await Conversores.Conversores_for_bytesAsync(update.Caminho);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //formação

        public async Task<Formacao> PostFormacaoAsync(FormacaoDTO form)
        {

            try
            {
                var modelo = mapper.Map<Formacao>(form);
                await context.Formacao.AddAsync(modelo);
                await context.SaveChangesAsync();
                return modelo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Formacao>> GetFormacaoAsync()
        {

            try
            {
                var result = await context.Formacao.Include(x=>x.Cursos).ThenInclude(x=>x.Departamento).ToListAsync();
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Formacao> GetFormacaoByIdAsync(int id)
        {

            try
            {
                var result = await context.Formacao.Include(x => x.Cursos).ThenInclude(x => x.Departamento).FirstOrDefaultAsync(x=>x.ID==id);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Editar Formacao
        public async Task<bool> PutFormacaoAsync(UpdateFormacaoID update)
        {
            try
            {
                var result = await context.Formacao.FirstOrDefaultAsync(x=>x.ID==update.ID);
                if (result != null) 
                {
                    result.NomeFormacao = update.NomeFormacao;
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region deletes
        //Delete curso
        public async Task<bool> DeletetCursoAsync(int id)
        {

            try
            {
                var result = await context.Cursos
                    .FirstOrDefaultAsync(x => x.ID == id);
                if (result != null)
                {
                    context.Cursos.Remove(result);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //delete formação
        //Delete curso
        public async Task<bool> DeleteFormacaoAsync(int id)
        {

            try
            {
                var result = await context.Formacao
                    .FirstOrDefaultAsync(x => x.ID == id);
                if (result != null)
                {
                    context.Formacao.Remove(result);
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
