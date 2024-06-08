using AutoMapper;
using ISCED_Benguela.Data.Context;
using ISCED_Benguela.Modelos.DTO;
using ISCED_Benguela.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ISCED_Benguela.Data.Repository
{
    public class DisciplinaRepository
    {
        private readonly IMapper mapper;
        private readonly IscedDbContext context;

        public DisciplinaRepository(IMapper mapper, IscedDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public async Task<Disciplina> PostDisciplinaAsync(DisciplinasDTO disci)
        {

            try
            {
                var modelo = mapper.Map<Disciplina>(disci);
                await context.Disicplina.AddAsync(modelo);
                await context.SaveChangesAsync();
                return modelo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Disciplina> GetDisciplinaAsync(int idDesc)
        {

            try
            {
                var result = await context.Disicplina
                    .Include(x=>x.Curso).ThenInclude(x => x.Departamento)
                    .FirstOrDefaultAsync(x => x.ID == idDesc);
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

        public async Task<List<Disciplina>> GetDisciplinaAsync()
        {

            try
            {
                var result = await context.Disicplina
                    .Include(x=>x.Curso).ThenInclude(x=>x.Departamento)
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

        //deletar
        //Delete curso
        public async Task<bool> DeleteDisciplinaAsync(int id)
        {

            try
            {
                var result = await context.Disicplina
                    .FirstOrDefaultAsync(x => x.ID == id);
                if (result != null)
                {
                    context.Disicplina.Remove(result);
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

        //editar disciplina
        public async Task<bool>putDisciplina(UpdateDisiciplinasDTO update)
        {
            try
            {
                var result = await context.Disicplina.FirstOrDefaultAsync(x => x.ID == update.ID);
                if (result != null) 
                {
                    result.NomeDisciplina=update.NomeDisciplina;
                    result.CursoID=update.CursoID;
                    await context.SaveChangesAsync(); return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
