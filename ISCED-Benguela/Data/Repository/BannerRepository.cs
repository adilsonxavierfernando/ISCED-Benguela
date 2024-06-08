using AutoMapper;
using ISCED_Benguela.Data.Context;
using ISCED_Benguela.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ISCED_Benguela.Data.Repository
{
    public class BannerRepository
    {
        private readonly IMapper mapper;
        private readonly IscedDbContext context;

        public BannerRepository(IMapper mapper, IscedDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<List<Banner>> GetAllAsync()
        {
            try
            {
                var result = await context.Banner.ToListAsync();
                if (result == null) 
                {
                    return result;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
