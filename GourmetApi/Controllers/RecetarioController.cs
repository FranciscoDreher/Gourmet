using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Gourmet;
using GourmetApi.DTO;
using GourmetApi.Extensions;
using GourmetApi.Repository;

namespace GourmetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecetarioController : ControllerBase
    {
        private readonly IRecetarioRepository recetarioRepository;

        public RecetarioController(IRecetarioRepository recetarioRepository)
        {
            this.recetarioRepository = recetarioRepository;
        }

        // GET: api/Recetario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecetarioDTO>>> GetRecetarios()
        {
            var recetarios = await this.recetarioRepository.FindAll();
            var recetariosDTO = recetarios.Select(r => r.ConvertToDTO()).ToList();

            return recetariosDTO;
        }

        // GET: api/Recetario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecetarioDTO>> GetRecetario(int id)
        {
            var recetario = await this.recetarioRepository.FindById(id);

            if (recetario == null)
            {
                return NotFound();
            }

            return recetario.ConvertToDTO();
        }

        // PUT: api/Recetario/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecetario(int id, RecetarioDTO recetarioDTO)
        {
            if (id != recetarioDTO.RecetarioId)
            {
                return BadRequest();
            }

            var recetario = new Recetario();
            recetario.RecetarioId = recetarioDTO.RecetarioId;
            recetario.SetTitulo(recetarioDTO.Titulo);

            await this.recetarioRepository.Update(id, recetario);

            return NoContent();
        }

        // POST: api/Recetario
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RecetarioDTO>> PostRecetario(RecetarioDTO recetarioDTO)
        {
            var recetarioParaCrear = new Recetario();
            recetarioParaCrear.RecetarioId = recetarioDTO.RecetarioId;
            recetarioParaCrear.SetTitulo(recetarioDTO.Titulo);

            var recetario = await this.recetarioRepository.Create(recetarioParaCrear);

            return CreatedAtAction(nameof(GetRecetario), new { id = recetario.RecetarioId }, recetario.ConvertToDTO());
        }

        // DELETE: api/Recetario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RecetarioDTO>> DeleteRecetario(int id)
        {
            var recetario = await this.recetarioRepository.Delete(id);

            return recetario.ConvertToDTO();
        }

        // GET: api/Recetario
        [HttpGet("{id:int}/Comidas")]
        public async Task<ActionResult<IEnumerable<ComidaDTO>>> GetComidasDelRecetario(int id)
        {
            var comidas = await this.recetarioRepository.GetComidasDelRecetario(id);
            var comidasDTO = comidas.Select(c => c.ConvertToDTO()).ToList();

            return comidasDTO;
        }
    }
}
