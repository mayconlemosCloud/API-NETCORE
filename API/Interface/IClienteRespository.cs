using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Interface
{
    public interface IClienteRepository
    {
         Task<List<Cliente>> GetAll();

         Task<List<Cliente>> Get(Cliente cliente);   
            
         Task<string> Create(Cliente cliente);
         Task<Cliente> Delete(Cliente cliente);

         Task<Cliente> Update(Cliente cliente);
 

         
    }
}
