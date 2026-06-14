using apiaulasindb.Data;
using apiaulasindb.Entidades;
using apiaulasindb.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiaulasindb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _context;
        public UsuarioController(DataContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> Get()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return Ok(usuarios.Select(u => new UsuarioDto { Id = u.Id, Nombre = u.Nombre, Correo = u.Correo, Rol = u.Rol }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> GetById(int id)
        {
            var u = await _context.Usuarios.FindAsync(id);
            if (u == null) return NotFound("Usuario no encontrado.");
            return Ok(new UsuarioDto { Id = u.Id, Nombre = u.Nombre, Correo = u.Correo, Rol = u.Rol });
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> Post(CreateUsuarioDto dto)
        {
            var nuevo = new Usuario { Nombre = dto.Nombre, Correo = dto.Correo, Rol = dto.Rol };
            _context.Usuarios.Add(nuevo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = nuevo.Id }, new UsuarioDto { Id = nuevo.Id, Nombre = nuevo.Nombre, Correo = nuevo.Correo, Rol = nuevo.Rol });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CreateUsuarioDto dto)
        {
            var u = await _context.Usuarios.FindAsync(id);
            if (u == null) return NotFound();
            u.Nombre = dto.Nombre; u.Correo = dto.Correo; u.Rol = dto.Rol;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var u = await _context.Usuarios.FindAsync(id);
            if (u == null) return NotFound();
            _context.Usuarios.Remove(u);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
