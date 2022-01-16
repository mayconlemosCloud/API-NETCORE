using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Interface;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace API.Repositorys
{
    public class CidadeRepository : ICidadeRepository
    {
        readonly Context _context;

        public CidadeRepository(Context context)
        {
           _context = context;
        }

        public async Task<string> Create(Cidade cidade)
        {
            _context.Add(cidade);
            var retorno = await _context.SaveChangesAsync();
            return "OK";
        }

        public async Task<List<Cidade>> Get(Cidade cidade)
        {
           var retorno = await _context.Cidade
           .Where(x => x.Nome == cidade.Nome | x.Estado == cidade.Estado)          
           .ToListAsync();
           return retorno;
        }

        public Task<List<Cidade>> GetAll()
        {
           
            return _context.Cidade.ToListAsync();
        }

       
        async Task<Cidade> ICidadeRepository.Delete(Cidade cidade)
        {
            _context.Cidade.Remove(cidade);
             await _context.SaveChangesAsync();
            return cidade;
           

        }

       
    }
}
