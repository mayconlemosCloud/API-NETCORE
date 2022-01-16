using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Interface;
using API.Models;

using Microsoft.EntityFrameworkCore;


namespace API.Repositorys
{
    public class ClienteRepository : IClienteRepository
    {
        readonly Context _context;

        public ClienteRepository(Context context)
        {
           _context = context;
        }

        public async Task<string> Create(Cliente cliente)
        {
            _context.Add(cliente);
            var retorno = await _context.SaveChangesAsync();
            return "OK";
        }

        public async Task<List<Cliente>> Get(Cliente cliente)
        {
            var retorno = await _context.Cliente
           .Where(x => x.Nome == cliente.Nome | x.ClienteId == cliente.ClienteId).Include(x => x.Cidade)          
           .ToListAsync();
           return retorno;
        }

        public Task<List<Cliente>> GetAll()
        {
             return _context.Cliente.Include(x=> x.Cidade ).ToListAsync();
        }


        
        public async Task<Cliente> Delete(Cliente cliente)
        {
             _context.Cliente.Remove(cliente);
             await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> Update( Cliente cliente)
        {

              _context.Update(cliente);
              await _context.SaveChangesAsync();
              return cliente;
        }
    }
}
