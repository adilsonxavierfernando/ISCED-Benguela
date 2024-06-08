using AutoMapper;
using ISCED_Benguela.Data.Context;
using ISCED_Benguela.Modelos;
using ISCED_Benguela.Modelos.DTO;
using Microsoft.EntityFrameworkCore;

namespace ISCED_Benguela.Data.Repository
{
    public class InfoSiteRepository
    {
        private readonly IMapper mapper;
        private readonly IscedDbContext context;

        public InfoSiteRepository(IMapper mapper, IscedDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<Feedbacks>PostFeedbackAsyn(FeedbackDTO dto)
        {
            try
            {
                var modelo = mapper.Map<Feedbacks>(dto);
                await context.feedbacks.AddAsync(modelo);
                await context.SaveChangesAsync();
                return modelo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<InfoSite> EditeInfoSiteAsync(InfoSite dto)
        {
            try
            {
                //dto.ContactoID = dto.Contacto.ID;
                //dto.EnderecoID = dto.Endereco.ID;
                context.InfoSites.Update(dto);

                //context.InfoSites.Attach(dto);
                //context.Entry(dto).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return dto;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<InfoSite> GetInfoSiteAsync()
        {

            try
            {
                var result = await context.InfoSites
                    .Include(x=>x.Contacto)
                    .Include(x=>x.Endereco)
                    .Include(x=>x.Redes)
                    .FirstOrDefaultAsync();
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

        //get by id
        public async Task<InfoSite> GetInfoSiteAsync(int id)
        {

            try
            {
                var result = await context.InfoSites
                    .Include(x => x.Contacto)
                    .Include(x => x.Endereco)
                    .Include(x => x.Redes)
                    .FirstOrDefaultAsync(x=>x.ID==id);
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
    }
}
