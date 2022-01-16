using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Interface
{
    public interface ICidadeRepository
    {
         Task<List<Cidade>> GetAll();

         Task<List<Cidade>> Get(Cidade cidade);   
            
         Task<string> Create(Cidade cidade);

         Task<Cidade> Delete(Cidade cidade);

         
    }
}
