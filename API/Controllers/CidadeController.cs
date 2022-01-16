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
    public class CidadeController : Controller
    {
        readonly ICidadeRepository _cidadeRepository;
        readonly Context _context;
        public CidadeController(ICidadeRepository cidadeRepository, Context context)
        {
            _cidadeRepository = cidadeRepository;
            _context = context;
        }

        /// <summary>
        /// Listar todas as cidades
        /// </summary>    
        [HttpGet("~/api/[controller]/todos")]
        public async Task<IActionResult> GetAll()
        {


            return Ok(await _cidadeRepository.GetAll());


        }

        /// <summary>
        /// Criar uma  cidade
        /// Não é necessário passar o ID, ele é gerado automaticamente
        /// </summary> 
        [HttpPost("~/api/[controller]/salvar")]
        public async Task<IActionResult> Create([FromBody] Cidade cidade)
        {
            var retorno = await _cidadeRepository.Create(cidade);
            return Ok(retorno);
        }


        
        /// <summary>
        /// Resgata uma cidade pelo Nome e Estado      
        /// </summary> 
        [HttpPost("~/api/[controller]/pegar")]
        public async Task<IActionResult> Get([FromBody] Cidade cidade)
        {

            var retorno = await _cidadeRepository.Get(cidade);
            return Ok(retorno);

        }

        /// <summary>
        /// Deletar uma cidade pelo ID.Deve ser passado o ID
        /// </summary> 
        [HttpDelete("~/api/[controller]/deletar/{CidadeId}")]
        public async Task<IActionResult> Deleta(int CidadeId)
        {
            var Cidade = await _context.Cidade.FindAsync(CidadeId);


            if (Cidade == null)
            {
                return NoContent();
            }

            var retorno = await _cidadeRepository.Delete(Cidade);

            var resultado = new { cidade = retorno, msg = "Cidade Deletada" };
            return Ok(resultado);
        }
    }
}
