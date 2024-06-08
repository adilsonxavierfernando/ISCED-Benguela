using AutoMapper;
using ISCED_Benguela.Data.Context;
using ISCED_Benguela.Modelos.DTO;
using ISCED_Benguela.Modelos;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ISCED_Benguela.Data.Repository
{
    public class MembershipRepository
    {
        private readonly IMapper mapper;
        private readonly IscedDbContext context;

        public MembershipRepository(IMapper mapper, IscedDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public async Task<MembroDireccao> PostMembrosAsync(MembershipDTO prof)
        {

            try
            {
                prof.Foto.Ficheiro = await Conversores.Conversores_for_bytesAsync(prof.Foto.Caminho);
                prof.Foto.Extensao = "PNG";
                var modelo = mapper.Map<MembroDireccao>(prof);
                await context.Funcionarios.AddAsync(modelo);
                await context.SaveChangesAsync();
                return modelo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MembroDireccao> GetMemberShipAsync(int id)
        {

            try
            {
                var result = await context.Funcionarios
                     .Include(x => x.RedesSociais)
                    .Include(x => x.Foto)
                    .FirstOrDefaultAsync(x=>x.ID == id);
                
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
        public async Task<bool> PutMemberShipAsync(UpdateMembershipDTO update)
        {
            try
            {
                
             
                var result= await context.Funcionarios.FirstOrDefaultAsync(x=>x.ID==update.ID);
                if (result!=null)
                {
                    if (update.Foto is not null)
                        await atualizarFoto(update);
                    await atualizarRedes(update.RedesSociais);
                    result.NomeFuncionario = update.NomeFuncionario;
                    result.Cargo = update.Cargo;
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

        private async Task atualizarRedes(UpdateRedesSociaisDTO update)
        {
            var result = await context.RedeSociais.FirstOrDefaultAsync(x => x.ID == update.ID);
            if (result is not null)
            {
                result.Facebook = update.Facebook;
                result.Youtube = update.Youtube;
                result.Linkedin = update.Linkedin;
                result.Instagram = update.Instagram;
                await context.SaveChangesAsync();
            }
        }

        private async Task atualizarFoto(UpdateMembershipDTO update)
        {
            try
            {
                var result = await context.Capas.FirstOrDefaultAsync(x => x.ID == update.Foto.ID);
                if (result is not null)
                {
                    result.Ficheiro = await Conversores.Conversores_for_bytesAsync(update.Foto.Caminho);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<MembroDireccao>> GetMembershipAsync()
        {

            try
            {
                var result = await context.Funcionarios
                    .Include(x => x.RedesSociais)
                    .Include(x => x.Foto)
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
        public async Task<bool> DeleteMembroAsync(int id)
        {

            try
            {
                var result = await context.Funcionarios
                    .Include(x => x.RedesSociais)
                    .Include(x => x.Foto)
                    .FirstOrDefaultAsync(x => x.ID == id);
                if (result != null)
                {
                    context.Funcionarios.Remove(result);
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

