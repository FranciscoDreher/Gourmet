using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GourmetApi.DTO;
using Gourmet;
using GourmetApi.Extensions;
using GourmetApi.Repository;

namespace GourmetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComidaController : ControllerBase
    {
        private readonly ComidaRepository comidaRepository;

        public ComidaController(ComidaRepository comidaRepository)
        {
            this.comidaRepository = comidaRepository;
        }

        // GET: api/Comida
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComidaDTO>>> GetComidas()
        {
            var comidas = await this.comidaRepository.FindAll();
            var comidasDTO = comidas.Select(c => c.ConvertToDTO()).ToList();

            return comidasDTO;
        }

        // GET: api/Comida/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComidaDTO>> GetComida(int id)
        {
            var comida = await this.comidaRepository.FindById(id);

            if (comida == null)
            {
                return NotFound();
            }

            return comida.ConvertToDTO();
        }

        // PUT: api/Comida/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComida(int id, ComidaDTO comidaDTO)
        {
            if (id != comidaDTO.ComidaId)
            {
                return BadRequest();
            }
            var comida = new Comida();
            comida.ComidaId = comidaDTO.ComidaId;
            comida.SetNombre(comidaDTO.Nombre);

            await this.comidaRepository.Update(id, comida);

            return NoContent();
        }

        // POST: api/Comida
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ComidaDTO>> PostComida(ComidaDTO comidaDTO)
        {
            var comidaParaCrear = new Comida();
            comidaParaCrear.ComidaId = comidaDTO.ComidaId;
            comidaParaCrear.SetNombre(comidaDTO.Nombre);

            var comida = await this.comidaRepository.Create(comidaParaCrear);

            return CreatedAtAction(nameof(GetComida), new { id = comida.ComidaId }, comida.ConvertToDTO());
        }

        // DELETE: api/Comida/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ComidaDTO>> DeleteComida(int id)
        {
            var comida = await this.comidaRepository.Delete(id);

            return comida.ConvertToDTO();
        }
    }
}
