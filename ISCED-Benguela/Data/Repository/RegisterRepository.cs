using AutoMapper;
using ISCED_Benguela.Data.Context;
using ISCED_Benguela.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ISCED_Benguela.Data.Repository
{
    public class RegisterRepository
    {
        private readonly IMapper mapper;
        private readonly IscedDbContext context;
        private readonly EstudanteRepository estudante;
        private readonly ProfessorRepository professor;
        private readonly UsuarioRepository usuario;

        public RegisterRepository(IMapper mapper, IscedDbContext context, EstudanteRepository estudante, ProfessorRepository professor, UsuarioRepository usuario)
        {
            this.mapper = mapper;
            this.context = context;
            this.estudante = estudante;
            this.professor = professor;
            this.usuario = usuario;
        }

        public async Task<Modelos.Registro> Login(string username, string password)
        {
            try
            {
                var result = await context.Register.FirstOrDefaultAsync(x => x.Usuario == username && x.Password == password);
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

        public async Task<Professores>GetProfessorAsync(int id)
        {
            try
            {
                return await professor.GetProfessorAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Usuario> GetUsuarioAsync(int id)
        {
            try
            {
                return await usuario.GetUsuariosLoginAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateSenhaAsync(Modelos.Registro dados)
        {
            try
            {
              var put=await context.Register.FirstOrDefaultAsync(x=>x.ID==dados.ID);
                if (put is not null)
                {
                    put.Password=dados.Password;
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
        public async Task<Estudantes> GetEstudantesAsync(int id)
        {
            try
            {
                return await estudante.GetEstudantesAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
