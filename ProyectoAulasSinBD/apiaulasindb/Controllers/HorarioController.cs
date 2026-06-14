using apiaulasindb.Data;
using apiaulasindb.Entidades;
using apiaulasindb.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiaulasindb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HorarioController : ControllerBase
    {
        private readonly DataContext _context;

        public HorarioController(DataContext context)
        {
            _context = context;
        }

        // 1. GET ALL
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HorarioDto>>> Get()
        {
            var horarios = await _context.Horarios.ToListAsync();

            var horariosDto = horarios.Select(h => new HorarioDto
            {
                Id = h.Id,
                DiaSemana = h.DiaSemana,
                HoraInicio = h.HoraInicio,
                HoraFin = h.HoraFin
            }).ToList();

            return Ok(horariosDto);
        }

        // 2. GET BY ID
        [HttpGet("{id}")]
        public async Task<ActionResult<HorarioDto>> GetById(int id)
        {
            var h = await _context.Horarios.FindAsync(id);
            if (h == null) return NotFound("Horario no encontrado.");

            var horarioDto = new HorarioDto
            {
                Id = h.Id,
                DiaSemana = h.DiaSemana,
                HoraInicio = h.HoraInicio,
                HoraFin = h.HoraFin
            };

            return Ok(horarioDto);
        }

        // 3. POST (CREATE)
        [HttpPost]
        public async Task<ActionResult<HorarioDto>> Post(CreateHorarioDto dto)
        {
            var nuevoHorario = new Horario
            {
                DiaSemana = dto.DiaSemana,
                HoraInicio = dto.HoraInicio,
                HoraFin = dto.HoraFin
            };

            _context.Horarios.Add(nuevoHorario);
            await _context.SaveChangesAsync();

            var resultadoDto = new HorarioDto
            {
                Id = nuevoHorario.Id,
                DiaSemana = nuevoHorario.DiaSemana,
                HoraInicio = nuevoHorario.HoraInicio,
                HoraFin = nuevoHorario.HoraFin
            };

            return CreatedAtAction(nameof(GetById), new { id = resultadoDto.Id }, resultadoDto);
        }

        // 4. PUT (UPDATE)
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CreateHorarioDto dto)
        {
            var h = await _context.Horarios.FindAsync(id);
            if (h == null) return NotFound("Horario no encontrado.");

            h.DiaSemana = dto.DiaSemana;
            h.HoraInicio = dto.HoraInicio;
            h.HoraFin = dto.HoraFin;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 5. DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var h = await _context.Horarios.FindAsync(id);
            if (h == null) return NotFound("Horario no encontrado.");

            _context.Horarios.Remove(h);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}