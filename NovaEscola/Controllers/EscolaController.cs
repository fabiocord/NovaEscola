using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovaEscola.Controllers.Resources;
using NovaEscola.Core.Services;
using NovaEscola.Models;

namespace NovaEscola.Controllers
{
    
    [ApiController]
    public class EscolaController : ControllerBase
    {
        private readonly IEscolaService service;

        public EscolaController(IEscolaService _service)
        {
            this.service = _service;
        }

        // GET: api/Escola
        [Route("novaescola/api/escolas")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(IEnumerable<EscolaResource>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            try
            {                
                var escolas = await service.GetAll();
                return Ok(escolas);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [Route("novaescola/api/escolas/find")]        
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(IEnumerable<EscolaResource>), StatusCodes.Status200OK)]
        
        public async Task<IActionResult> GetAllFiltered([FromQuery] string name = null,[FromQuery] string uf = null)
        {
            try
            {
                EscolaQueryResource query = new EscolaQueryResource() { Name = name, UF = uf };
                var escolas = await service.Find(query);                
                return Ok(escolas);
            }
            catch (Exception)
            {
                return NotFound();
            }

        }
        // GET: api/Escola
        [Route("novaescola/api/escolas/{pageIndex}/{pageSize}")]
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(IEnumerable<EscolaResource>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPaged(int pageIndex, int pageSize)
        {
            try
            {                                         
                var escolas = await service.EscolasComTurmas(pageIndex,pageSize);          
                return Ok(escolas);
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        // GET: api/Escola/5
        [Route("novaescola/api/escola/{id:int:min(1)}")]
        [HttpGet]
        [ProducesResponseType(typeof(Escola), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var escola = await service.Get(id);
                return Ok(escola);
            }
            catch (Exception)
            {
                return NotFound();
            }
            
        }

        // POST: api/Escola
        [Route("novaescola/api/escola")]
        [HttpPost]
        [ProducesResponseType(typeof(EscolaResource), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] EscolaSaveResource escola)            
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var retorno = await service.Create(escola);
                
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status418ImATeapot, "Erro: "+ex.Message);                
            }            
        }

        // PUT: api/Escola/5
        [Route("novaescola/api/escola")]
        [HttpPut]        
        [ProducesResponseType(typeof(EscolaResource), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] EscolaSaveResource escola)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await service.Get(escola.Id) == null)
                    return NotFound();

                var retorno = await service.Update(escola);
                return Ok(retorno);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status418ImATeapot, "Erro: " + ex.Message);                
            }            
            
        }

        // DELETE: api/ApiWithActions/5
        [Route("novaescola/api/escola/{id:int:min(1)}")]
        [HttpDelete]        
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var retorno = await service.Delete(id);
            return Ok(retorno);
        }
    }
}
