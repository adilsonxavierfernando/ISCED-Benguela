﻿using AutoMapper;
using ISCED_Benguela.Data.Context;
using ISCED_Benguela.Modelos.DTO;
using ISCED_Benguela.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ISCED_Benguela.Data.Repository
{
    public class ProfessorRepository
    {
        private readonly IMapper mapper;
        private readonly IscedDbContext context;

        public ProfessorRepository(IMapper mapper, IscedDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public async Task<Professores> PostProfessorAsync(ProfessorDTO prof)
        {

            try
            {
                prof.Foto.Ficheiro = await Conversores.Conversores_for_bytesAsync(prof.Foto.Caminho);
                prof.Foto.Extensao = "PNG";
                var modelo = mapper.Map<Professores>(prof);
                await context.Professores.AddAsync(modelo);
                await context.SaveChangesAsync();
                return modelo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Professores> GetProfessorAsync(int idLogin)
        {

            try
            {
                var result = await context.Professores
                    .Include(x => x.Departamentos)
                    .Include(x => x.Contacto)
                    .Include(x => x.Morada)
                    .Include(x => x.Foto)
                      .Include(x => x.Redes)
                    .Include(x=>x.RegisterLogin)
                    .FirstOrDefaultAsync(x => x.RegisterLogin.ID == idLogin && !x.Bloqueado && x.Aprovado);
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

        public async Task<List<Professores>> GetProfessorAsync()
        {

            try
            {
                var result = await context.Professores
                    .Include(x=>x.Departamentos)
                    .Include(x=>x.Contacto)
                    .Include(x=>x.Morada)
                    .Include(x=>x.Foto)
                    .Include(x => x.Redes)
                    .Include(x => x.RegisterLogin)
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
        public async Task<Professores> GetProfessorByIdAsync(int id)
        {

            try
            {
                var result = await context.Professores
                    .Include(x => x.Departamentos)
                    .Include(x => x.Contacto)
                    .Include(x => x.Morada)
                    .Include(x => x.Foto)
                    .Include(x => x.RegisterLogin)
                    .Include (x => x.Redes)
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
        #region bloquear e excluir professor
        public async Task<bool> DeleteProfessorAsync(int id)
        {

            try
            {
                var result = await context.Professores
                    .FirstOrDefaultAsync(x => x.ID == id);
                if (result != null)
                {
                    context.Professores.Remove(result);
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

        //bloquear
        public async Task<bool> BloquearProfessorAsync(int id)
        {

            try
            {
                var result = await context.Professores
                    .FirstOrDefaultAsync(x => x.ID == id);
                if (result != null)
                {
                    result.Bloqueado = true;
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
        //alterar foto
        public async Task<bool> UpdateFotoAsync(int id, IFormFile Fotografia)
        {

            try
            {
                var result = await context.Capas
                    .FirstOrDefaultAsync(x => x.ID == id);
                
                if (result != null)
                {
                    result.Ficheiro = await Conversores.Conversores_for_bytesAsync(Fotografia);
                    result.Extensao = "PNG";
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

        public async Task<bool> UpdateGeralAsync(Professores model)
        {

            try
            {
                var result = await context.Professores
                    .FirstOrDefaultAsync(x => x.ID == model.ID
                    );

                if (result != null)
                {
                    result.Nome = model.Nome;
                    result.Sobrenome = model.Sobrenome;
                    result.Bibliografia = model.Bibliografia;
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
        public async Task<bool> UpdateEnderecoAsync(Professores model)
        {

            try
            {
                var result = await context.Endereco
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.ID == model.Morada.ID
                    );

                if (result != null)
                {
                    context.Endereco.Update(model.Morada);
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
        //social
        public async Task<bool> UpdateSocialAsync(Professores model)
        {

            try
            {
                var result = await context.RedeSociais
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.ID == model.Redes.ID
                    );

                if (result != null)
                {
                    context.RedeSociais.Update(model.Redes);
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
        //aprovar
        public async Task<bool> AprovarProfessorAsync(int id)
        {

            try
            {
                var result = await context.Professores
                    .FirstOrDefaultAsync(x => x.ID == id);
                if (result != null)
                {
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

        //ativar e desativar prof
        public async Task<bool> AtivarProfessorAsync(int id, bool estado)
        {

            try
            {
                var result = await context.Professores
                    .FirstOrDefaultAsync(x => x.ID == id);
                if (result != null)
                {
                    result.Ativo = !result.Ativo;
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

