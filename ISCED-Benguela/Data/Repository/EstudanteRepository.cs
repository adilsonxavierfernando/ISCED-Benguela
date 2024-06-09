using AutoMapper;
using ISCED_Benguela.Data.Context;
using ISCED_Benguela.Encapsulamento;
using ISCED_Benguela.Modelos;
using ISCED_Benguela.Modelos.DTO;
using MailKit.Net.Smtp;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ISCED_Benguela.Data.Repository
{
    public class EstudanteRepository
    {
        private readonly IMapper mapper;
        private readonly IscedDbContext context;

        public EstudanteRepository(IMapper mapper, IscedDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public async Task<Estudantes> PostEstudantesAsync(EstudanteDTO estudantes)
        {
          
            try
            {
                try
                {
                    var mail = new SendMailService();
                    string body = $"<h1>Olá,{estudantes.Nome} </h1>" +
                        $"<p>Sua Inscrição ao portal do Isced, foi <b>Enviada</p> pelo, que aguarda a aprovação administradores</p>" +
                        $"<hr><center><b>Portal Isced-benguela</b> - Pela formação superior de  melhores educadores. </center>";
                    await mail.SendEmail(estudantes.RegisterLogin.Usuario, "Inscrição no portal do Isced", body, true);
                }
                catch (SmtpCommandException ex)
                {
                    if (ex.ErrorCode == SmtpErrorCode.RecipientNotAccepted)
                    {
                        throw new SmtpCommandException(ex.ErrorCode, ex.StatusCode, "O E-mail fornecido não existe, informe um e-mail válido por favor");
                    }
                    else if (ex.ErrorCode == SmtpErrorCode.SenderNotAccepted)
                    {
                        throw new SmtpCommandException(ex.ErrorCode, ex.StatusCode, "O E-mail fornecido não existe, informe um e-mail válido por favor");
                    }
                    else if (ex.ErrorCode == SmtpErrorCode.MessageNotAccepted)
                    {
                        throw new SmtpCommandException(ex.ErrorCode, ex.StatusCode, "O E-mail fornecido não existe, informe um e-mail válido por favor");
                    }
                }
                estudantes.Avatar.Ficheiro = await Conversores.Conversores_for_bytesAsync(estudantes.Avatar.Caminho);
                estudantes.Avatar.Extensao = "PNG";
                var modelo = mapper.Map<Estudantes>(estudantes);
                await context.Estudantes.AddAsync(modelo);
                await context.SaveChangesAsync();
                return modelo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Estudantes> GetEstudantesAsync(int idLogin)
        {

            try
            {
                var result=await context.Estudantes
                    .Include(x=>x.Avatar)
                    .Include(x => x.Curso)
                    .ThenInclude(x => x.Departamento)
                    .FirstOrDefaultAsync(x=>x.RegisterLogin.ID==idLogin && !x.Bloqueado && x.Aprovado);
                if (result != null)
                {
                    await AtivarChatEstudanteAsync(result.ID,true);
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
        //
        public async Task<Estudantes> GetEstudantesByAsync(int id)
        {

            try
            {
                var result = await context.Estudantes
                    .Include(x => x.Avatar)
                    .Include(x => x.Curso)
                    .ThenInclude(x => x.Departamento)
                    .Include(x=>x.RegisterLogin)
                    .FirstOrDefaultAsync(x => x.ID == id && !x.Bloqueado && x.Aprovado);
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
        //

        public async Task<List<Estudantes>> GetEstudantesAsync()
        {

            try
            {
                var result = await context.Estudantes
                    .Include(x => x.Avatar)
                    .Include(x=>x.Curso)
                    .ThenInclude(x=>x.Departamento)
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
        //bloquear e eliminar estudante
        public async Task<bool> DeleteEstudanteAsync(int id)
        {

            try
            {
                var result = await context.Estudantes
                     .Include(x => x.Avatar)
                    .Include(x => x.Curso)
                    .FirstOrDefaultAsync(x => x.ID == id);
                if (result != null)
                {
                    context.Estudantes.Remove(result);
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

        public async Task<bool> BloquearEstudanteAsync(int id)
        {

            try
            {
                var result = await context.Estudantes
                    .FirstOrDefaultAsync(x => x.ID == id);
                if (result != null)
                {
                    result.Bloqueado = !result.Bloqueado;
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

        public async Task<bool> AtivarChatEstudanteAsync(int id, bool estado)
        {

            try
            {
                var result = await context.Estudantes
                    .FirstOrDefaultAsync(x => x.ID == id);
                if (result != null)
                {
                    result.Ativo = estado;
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

        public async Task<bool>PutEstudante(UpdateEstudanteDTO update)
        {
            try
            {
                var result = await context.Estudantes.FirstOrDefaultAsync(x => x.ID == update.ID);
                if (result != null) 
                {
                    result.Nome = update.Nome;
                    result.Sobrenome = update.Sobrenome;
                    await AtualizarLogin(update.RegisterLogin);
                    if(update.Avatar is not null)
                        await AtualizarFoto(update.Avatar);
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

        private async Task AtualizarFoto(UpdateCapaDTO avatar)
        {
            try
            {
                var result = await context.Capas.FirstOrDefaultAsync(x => x.ID == avatar.ID);
                if (result != null)
                {
                    result.Ficheiro = await Conversores.Conversores_for_bytesAsync(avatar.Caminho);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task AtualizarLogin(UpdateRegisterDTO update)
        {
            try
            {
                var result = await context.Register.FirstOrDefaultAsync(x => x.ID == update.ID);
                if (result != null)
                {
                    result.Usuario = update.Usuario;
                    result.Password = update.Password;
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> AprovarEstudanteAsync(int id)
        {

            try
            {
                var result = await context.Estudantes
                    .Include(x=>x.RegisterLogin)
                    .FirstOrDefaultAsync(x => x.ID == id);
                if (result != null)
                {
                    var mail = new SendMailService();
                    string body = $"<h1>Olá caríssimo estudante,{result.Nome} </h1>" +
                        $"<p>Sua Inscrição ao portal do Isced, foi <b>Aprovada</p> pelos administradores</p>" +
                        $"<br>Agora você pode reagir e estudar no portal.<br><br>Use o portal com responsabilidade" +
                        $"" +
                        $"<hr><center><b>Portal Isced-benguela</b> - Pela formação superior de  melhores educadores. </center>";
                    await mail.SendEmail(result.RegisterLogin.Usuario, "Inscrição no portal do Isced", body, true);

                    result.Aprovado = true;
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
