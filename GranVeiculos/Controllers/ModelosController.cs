using GranVeiculos.Data;
using GranVeiculos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GranVeiculos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ModelosController : ControllerBase
{
    private readonly AppDbContext _db;

    public ModelosController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var modelos = _db.Modelos
            .Include(m => m.Marca)
            .ToList();
        return Ok(modelos);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var modelo = _db.Modelos
            .Include(m => m.Marca)
            .FirstOrDefault(m => m.Id == id);
        if (modelo == null)
            return NotFound();
        return Ok(modelo);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Modelo modelo)
    {
        if (!ModelState.IsValid)
            return BadRequest("Modelo informado com problemas");
        _db.Modelos.Add(modelo);
        _db.SaveChanges();
        return CreatedAtAction(nameof(Get), modelo.Id, new { modelo });
    }

    [HttpPut("{id}")]
    public IActionResult Edit(int id, [FromBody] Modelo modelo)
    {
        if (!ModelState.IsValid || id != modelo.Id)
            return BadRequest("Modelo informado com problemas");
        _db.Modelos.Update(modelo);
        _db.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var modelo = _db.Modelos.Find(id);
        if (modelo == null)
            return NotFound("Modelo não encontrado!");
        _db.Modelos.Remove(modelo);
        _db.SaveChanges();
        return NoContent();
    }

}
