using AutoMapper;
using ISCED_Benguela.Data.Context;
using ISCED_Benguela.Modelos.DTO;
using ISCED_Benguela.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ISCED_Benguela.Data.Repository
{
    public class MateriaRepository
    {
        private readonly IMapper mapper;
        private readonly IscedDbContext context;

        public MateriaRepository(IMapper mapper, IscedDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public async Task<Materia> PostMateriaAsync(MateriaDTO disci)
        {

            try
            {
                disci.Capa.Ficheiro = await Conversores.Conversores_for_bytesAsync(disci.Capa.Caminho);
                disci.Capa.Extensao = "PNG";

                disci.Arquivo.Ficheiro = await Conversores.Conversores_for_bytesAsync(disci.Arquivo.Caminho);
                disci.Arquivo.Extensao = "pdf";

                var modelo = mapper.Map<Materia>(disci);
                modelo.DataPublicacao = DateTime.Now.ToUniversalTime();
                await context.Materias.AddAsync(modelo);
                await context.SaveChangesAsync();
                return modelo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> PutMateria(UpdateMateriaDTO update)
        {
            try
            {
                var result = await context.Materias
                    .FirstOrDefaultAsync(x => x.ID == update.ID);

                if (result is not null)
                {
                    result.Titulo = update.Titulo;
                    result.Conteudo = update.Conteudo;
                    result.DisciplinaID = update.DisciplinaID;
                    result.DepartamentosID = update.DepartamentosID;
                    if(update.Capa is not null)
                        await atualizarFoto(update);
               
                        
                    if (update.Arquivo is not null)
                        await atualizarArquivo(update);
               

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

        private async Task atualizarArquivo(UpdateMateriaDTO update)
        {
            try
            {
                var result = await context.Arquivos.FirstOrDefaultAsync(x => x.ID == update.Arquivo.ID);
                if (result is not null)
                {
                    result.Ficheiro = await Conversores.Conversores_for_bytesAsync(update.Arquivo.Caminho);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task atualizarFoto(UpdateMateriaDTO update)
        {
            try
            {
                var result = await context.Capas.FirstOrDefaultAsync(x => x.ID == update.Capa.ID);
                if (result is not null)
                {
                    result.Ficheiro = await Conversores.Conversores_for_bytesAsync(update.Capa.Caminho);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Comentarios
        public async Task<Comentarios> PostComentarioAsync(ComentarioDTO comentario)
        {

            try
            {
                var modelo = mapper.Map<Comentarios>(comentario);
                modelo.DataCriacao = DateTime.Now.ToUniversalTime();
                await context.Comentario.AddAsync(modelo);
                await context.SaveChangesAsync();
                return modelo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //respostas
        //Comentarios
        public async Task<Reposta> PostRespostaAsync(RespostaDTO dto)
        {

            try
            {
                var modelo = mapper.Map<Reposta>(dto);
                var result = await context.Comentario.FirstOrDefaultAsync(x => x.ID == modelo.ComentarioID);
                result.Respondido = true;
                //modelo.DataCriacao = DateTime.Now.ToUniversalTime();
                await context.Respostas
                    .AddAsync(modelo);
                await context.SaveChangesAsync();
                return modelo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Materia> GetMateriaAsync(int idMateria)
        {
            try
            {
                var result = await context.Materias
                     .Include(x => x.Professor).ThenInclude(y=>y.Foto)
                    .Include(x => x.Arquivo)
                    .Include(x => x.Capa)
                    .Include(x=>x.Disciplina)
                    .Include(x=>x.Departamentos)
                    .Include(x=>x.Comentarios).ThenInclude(x=>x.Estudante).Include(x=>x.Comentarios).ThenInclude(x=>x.Respostas)
                    .FirstOrDefaultAsync(x => x.ID == idMateria);
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
        //materia by departamento
        public async Task<List<Materia>> GetMateriaByDepartamentoAsync(int idDepartamento)
        {
            try
            {
                var result = await context.Materias
                     .Include(x => x.Professor).ThenInclude(y => y.Foto)
                    .Include(x => x.Arquivo)
                    .Include(x => x.Capa)
                    .Include(x => x.Disciplina)
                    .Include(x => x.Departamentos)
                    .Include(x => x.Comentarios).ThenInclude(x => x.Estudante).Include(x => x.Comentarios).ThenInclude(x => x.Respostas)
                    .Where(x => x.DepartamentosID == idDepartamento).ToListAsync();
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

        public async Task<List<Materia>> GetMateriaAsync()
        {

            try
            {
                var result = await context.Materias
                   .Include(x => x.Professor).ThenInclude(y => y.Foto)
                    .Include(x => x.Arquivo)
                    .Include(x => x.Capa)
                    .Include(x => x.Disciplina)
                    .Include(x => x.Departamentos)
                    .Include(x => x.Comentarios).ThenInclude(x => x.Estudante).Include(x => x.Comentarios).ThenInclude(x => x.Respostas)
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

        public async Task<List<Reposta>> GetRespostasAsync(int comentario)
        {

            try
            {
                var result = await context.Respostas
                    .Include(x=>x.Comentario).ThenInclude(x=>x.Estudante)
                    .Include(x=>x.Professor)
                   .Where(x => x.Comentario.ID==comentario).ToListAsync();
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
        //comentarios
        public async Task<List<Reposta>> GetRespostasAsync()
        {

            try
            {
                var result = await context.Respostas
                    .Include(x => x.Comentario).ThenInclude(x => x.Estudante)
                    .Include(x => x.Professor).ToListAsync();
                   
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

        public async Task<List<Comentarios>> GetComentariosAsync(int user)
        {

            try
            {
                var result = await context.Comentario
                    .Include(x=>x.Materia).ThenInclude(x=>x.Disciplina)
                    .Include(x=>x.Estudante)
                   .Where(x=>x.EstudanteID==user).ToListAsync();
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

        public async Task<List<Comentarios>> GetComentariosAsync()
        {

            try
            {
                var result = await context.Comentario
                    .Include(x => x.Materia).ThenInclude(x => x.Disciplina)
                    .Include(x => x.Estudante)
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

        public async Task<List<Comentarios>> GetComentariosByInstrutorAsync(int idTeacher)
        {

            try
            {
                var result = await context.Comentario
                    .Include(x => x.Materia).ThenInclude(x => x.Disciplina)
                    .Include(x => x.Estudante)
                   .Where(x => x.Materia.ProfessorID == idTeacher).ToListAsync();
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
        #region Deletar registros e dar stop
        //Delete curso
        public async Task<bool> DeleteMateriaAsync(int id)
        {

            try
            {
                var result = await context.Materias
                    .FirstOrDefaultAsync(x => x.ID == id);
                if (result != null)
                {
                    context.Materias.Remove(result);
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

        //deletar comentario
        public async Task<bool> DeleteComentarioAsync(int id)
        {

            try
            {
                var result = await context.Comentario
                    .FirstOrDefaultAsync(x => x.ID == id);
                if (result != null)
                {
                    context.Comentario.Remove(result);
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
        //stop Materia
        public async Task<bool> StopMateriaAsync(int id)
        {

            try
            {
                var result = await context.Materias
                    .FirstOrDefaultAsync(x => x.ID == id);
                if (result != null)
                {
                    result.Visivel = !result.Visivel;
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

