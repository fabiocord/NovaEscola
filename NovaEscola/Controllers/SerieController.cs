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
    public class SerieController : ControllerBase
    {
        private readonly ISerieService service;

        public SerieController(ISerieService service)
        {
            this.service = service;
        }

        // GET: api/Serie
        [Route("novaescola/api/series")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SerieResource>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAll()
        {
            try
            {                
                var series = await service.GetAll();
                return Ok(series);
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        [Route("novaescola/api/series/{query}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SerieResource>), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllFiltered(SerieQueryResource query = null)
        {
            try
            {                
                var series = await service.Find(query);                
                return Ok(series);
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        // GET: api/Serie/5
        [Route("novaescola/api/serie/{id:int:min(1)}")]
        [HttpGet]
        [ProducesResponseType(typeof(SerieResource), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var serie = await service.Get(id);
                return Ok(serie);
            }
            catch (NotImplementedException)
            {
                return NotFound();
            }
        }
    }
}
