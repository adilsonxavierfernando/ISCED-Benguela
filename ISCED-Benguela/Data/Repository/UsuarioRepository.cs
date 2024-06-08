using AutoMapper;
using ISCED_Benguela.Data.Context;
using ISCED_Benguela.Modelos.DTO;
using ISCED_Benguela.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ISCED_Benguela.Data.Repository
{
    public class UsuarioRepository
    {
        private readonly IMapper mapper;
        private readonly IscedDbContext context;

        public UsuarioRepository(IMapper mapper, IscedDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public async Task<Usuario> PostUsuarioAsync(UsuarioDTO disci)
        {

            try
            {
                var modelo = mapper.Map<Usuario>(disci);
                await context.Usuarios.AddAsync(modelo);
                await context.SaveChangesAsync();
                return modelo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Usuario> UpdateUsuarioAsync(Modelos.Usuario usuario)
        {

            try
            {
                var result=await context.Usuarios.Include(x=>x.RegisterLogin).AsNoTracking()
                    .FirstOrDefaultAsync(x=>x.ID==usuario.ID);
                usuario.RegisterLogin.Role = result.RegisterLogin.Role;
                context.Usuarios.Update(usuario);
                await context.SaveChangesAsync();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Usuario> GetUsuariosLoginAsync(int idUsuario)
        {

            try
            {
                var result = await context.Usuarios
                    .Include(x=>x.RegisterLogin)
                    .FirstOrDefaultAsync(x => x.RegisterLogin.ID == idUsuario);
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

        public async Task<Usuario> GetUsuarioAsync(int idUsuario)
        {

            try
            {
                var result = await context.Usuarios
                    .Include(x => x.RegisterLogin)
                    .FirstOrDefaultAsync(x => x.ID == idUsuario);
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


        public async Task<List<Usuario>> GetUsuariosAsync()
        {

            try
            {
                var result = await context.Usuarios.ToListAsync();
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
        //Usuario
        public async Task<bool> DeleteUsuarioAsync(int id)
        {

            try
            {
                var result = await context.Usuarios
                    .FirstOrDefaultAsync(x => x.ID == id);
                if (result != null)
                {
                    context.Usuarios.Remove(result);
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

