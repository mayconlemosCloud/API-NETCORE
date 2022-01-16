using System;
using System.Threading.Tasks;
using API.Data;
using API.Interface;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        readonly IClienteRepository _clienteRepository;
        readonly Context _context;
        public ClienteController(IClienteRepository clienteRepository, Context context)
        {
            _clienteRepository = clienteRepository;
            _context = context;
        }

         /// <summary>
        /// Listar todas as clientes
        /// </summary> 
        [HttpGet("~/api/[controller]/todos")]
        public async Task<IActionResult> GetAll()
        {


            return Ok(await _clienteRepository.GetAll());


        }

        /// <summary>
        /// Criar um cliente
        /// Não é necessário passar o ID, ele é gerado automaticamente.
        /// CidadeId é o ID da cidade que o cliente pertence,  é necessário passar o ID
        /// </summary> 
        [HttpPost("~/api/[controller]/salvar")]
        public async Task<IActionResult> Create([FromBody] Cliente cliente)
        {
            var retorno = await _clienteRepository.Create(cliente);
            return Ok(retorno);
        }

        /// <summary>
        /// Resgata uma cidade pelo Nome e ClienteId      
        /// </summary> 
        [HttpPost("~/api/[controller]/pegar")]
        public async Task<IActionResult> Get([FromBody] Cliente  cliente)
        {

            var retorno = await _clienteRepository.Get(cliente);
            return Ok(retorno);

        }

        /// <summary>
        /// Deletar um cliente pelo ID.Deve ser passado o ID
        /// </summary> 
       [HttpDelete("~/api/[controller]/deletar/{ClienteId}")]
        public async Task<IActionResult> Deleta(int ClienteId)
        {
            var Cliente = await _context.Cliente.FindAsync(ClienteId);


            if (Cliente == null)
            {
                return NoContent();
            }

            var retorno = await _clienteRepository.Delete(Cliente);

            var resultado = new { cidade = retorno, msg = "Cliente Deletado" };
            return Ok(resultado);
        }

         /// <summary>
        /// Atualizar um cliente pelo ID.Deve ser passado o ClienteId no corpo da requisição
        /// </summary> 
        [HttpPut("~/api/[controller]/atualizar/")]
        public async Task<IActionResult> Update([FromBody] Cliente cliente)
        {
            var clienteAtual = await _context.Cliente.AsNoTracking().FirstOrDefaultAsync(x => x.ClienteId == cliente.ClienteId);
            
            if (clienteAtual == null)
            {
                return NotFound("Cliente não encontrado");
            }
            
            var retorno = await _clienteRepository.Update(cliente);

          
            return Ok(retorno);
        }


    }
}
