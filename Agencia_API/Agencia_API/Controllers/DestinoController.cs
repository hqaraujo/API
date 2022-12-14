using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Agencia_API.Models;

namespace Agencia_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinoController : ControllerBase
    {
    
private readonly DestinoDbContext _context;

        public DestinoController(DestinoDbContext context) { _context = context; }


        // GET: api/\Destino - LISTA DE DESTINO
        [HttpGet]
        public IEnumerable<Destino> GetDestino()
        {
            return _context.Destinos;
        }
        // GET: api/Destino/id - LISTA DESTINO POR ID
        [HttpGet("{id}")]
        public IActionResult GetDestinoPorId(int id)
        {
            Destino destino = _context.Destinos.SingleOrDefault(modelo => modelo.DestinoId == id);
            if (destino == null)
            {
                return NotFound();
            }
            return new ObjectResult(destino);
        }

        // CRIA UM NOVO DESTINO      
        [HttpPost]
        public IActionResult CriarDestino(Destino item)
        {
            if (item == null) { return BadRequest(); }

            _context.Destinos.Add(item); _context.SaveChanges(); return new ObjectResult(item);
        }
        // ATUALIZA UM DESTINO EXISTENTE
        [HttpPut("{id}")]
        public IActionResult AtualizaCurso(int id, Destino item)
        {
            if (id != item.DestinoId)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();



            return new NoContentResult();
        }
        // APAGA UM DESTINO POR ID
        [HttpDelete("{id}")]
        public IActionResult DeletaDestino(int id)
        {
            var destino = _context.Destinos.SingleOrDefault(m => m.DestinoId == id);



            if (destino == null)
            {
                return BadRequest();
            }



            _context.Destinos.Remove(destino);
            _context.SaveChanges();
            return Ok(destino);
        }

    }

}
