using AutoMapper;
using ISCED_Benguela.Data.Context;
using ISCED_Benguela.Modelos.DTO;
using ISCED_Benguela.Modelos;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ISCED_Benguela.Data.Repository
{
    public class DepartamentosRepository
    {
        private readonly IMapper mapper;
        private readonly IscedDbContext context;

        public DepartamentosRepository(IMapper mapper, IscedDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public async Task<Departamentos> PostDepartamentoAsync(DepartamentoDTO dep)
        {

            try
            {
                if (dep.isPrincipal)
                {
                    await AnularPrincipal(dep.isPrincipal);
                }
                var modelo = mapper.Map<Departamentos>(dep);
                await context.Departamentos.AddAsync(modelo);
                await context.SaveChangesAsync();
                return modelo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Departamentos> GetDepartamentoAsync(int idDepartamento)
        {

            try
            {
                var result = await context.Departamentos
                      .Include(x => x.ChefeDepartamento).ThenInclude(x => x.Foto)
                    .FirstOrDefaultAsync(x => x.ID == idDepartamento);
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

        public async Task<List<Departamentos>> GetDepartamentosAsync()
        {

            try
            {
                var result = await context.Departamentos
                    .Include(x=>x.ChefeDepartamento).ThenInclude(x=>x.Foto)
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

        //editar
        public async Task<bool> PutDepartamentoAsync(UpdateDepartamentoDTO update)
        {

            try
            {
                var result = await context.Departamentos
                    .FirstOrDefaultAsync(x=>x.ID==update.ID);
                if (result != null)
                {
                    if (update.isPrincipal)
                    {
                        await AnularPrincipal(update.isPrincipal);
                    }
                 

                    result.NomeDepartamento = update.NomeDepartamento;
                    result.ChefedepartamentoID = update.ChefedepartamentoID;
                    result.Descricao = update.Descricao;
                    result.isPrincipal = update.isPrincipal;
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

        private async Task AnularPrincipal(bool isPrincipal)
        {
            var result = await context.Departamentos
       .Where(d => d.isPrincipal == true)
       .ToListAsync();
            if (result!=null) {
                foreach (var item in result)
                {
                    item.isPrincipal = false;
                }
            }
       
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeletetDepartamentosAsync(int id)
        {

            try
            {
                var result = await context.Departamentos
                    .Include(x => x.ChefeDepartamento).ThenInclude(x => x.Foto)
                    .FirstOrDefaultAsync(x=>x.ID==id);
                if (result != null)
                {
                    context.Departamentos.Remove(result);
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
    }
}
