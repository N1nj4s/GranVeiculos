using System.Threading.Tasks;
using GranVeiculos.Data;
using GranVeiculos.Models;
using Microsoft.AspNetCore.Mvc;

namespace GranVeiculos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoresController(AppDbContext db) : ControllerBase
    {
        private readonly AppDbContext _db = db;

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Cores.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cor = _db.Cores.Find(id);
            if (cor == null)
                return NotFound();
            return Ok(cor);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Cor cor)
        {
            if (!ModelState.IsValid)
                return BadRequest("Cor informada com problemas");
            _db.Cores.Add(cor);
            _db.SaveChanges();
            return CreatedAtAction(nameof(Get), cor.Id, new { cor });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] Cor cor)
        {
            if (!ModelState.IsValid || id != cor.Id)
                return BadRequest("Cor informada com problemas");
            _db.Cores.Update(cor);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cor = _db.Cores.Find(id);
            if (cor == null)
                return NotFound();
            _db.Cores.Remove(cor);
            _db.SaveChanges();
            return NoContent();
        }
    }
}