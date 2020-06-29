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
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaService service;

        public TurmaController(ITurmaService service)
        {
            this.service = service;
        }

        // GET: api/Turma
        [Route("novaescola/api/turmas")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TurmaResource>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            try
            {                
                var turmas = await service.GetAll();
                return Ok(turmas);                                
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        [Route("novaescola/api/turmas/find")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TurmaResource>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllFiltered([FromQuery] string nomeTurma = null)
        {
            try
            {
                TurmaQueryResource query = new TurmaQueryResource() { NomeTurma = nomeTurma };
                var turmas = await service.Find(query);               
                return Ok(turmas);
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        // GET: api/Escola
        [Route("novaescola/api/turmas/{pageIndex}/{pageSize}")]
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(IEnumerable<TurmaResource>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPaged(int pageIndex, int pageSize)
        {
            try
            {
                var turmas = await service.TurmasWithSerieEscola(pageIndex, pageSize);
                return Ok(turmas);
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        // GET: api/Turma/5
        [Route("novaescola/api/turma/{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(TurmaResource), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var turma = await service.Get(id);
                return Ok(turma);
            }
            catch (NotImplementedException)
            {
                return NotFound();
            }

        }

        // POST: api/Turma
        [Route("novaescola/api/turma")]
        [HttpPost]
        [ProducesResponseType(typeof(TurmaResource), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] TurmaSaveResource turma)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var retorno = await service.Create(turma);

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status418ImATeapot, "Erro: " + ex.Message);
            }
        }

        // PUT: api/Turma/5
        [Route("novaescola/api/turma")]
        [HttpPut]
        [ProducesResponseType(typeof(TurmaResource), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] TurmaSaveResource turma)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await service.Get(turma.Id) == null)
                    return NotFound();

                var retorno = await service.Update(turma);
                return Ok(retorno);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status418ImATeapot, "Erro: " + ex.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [Route("novaescola/api/turma/{id}")]
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
