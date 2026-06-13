using Microsoft.AspNetCore.Mvc;
using apiaulasindb.Entidades;

namespace apiaulasindb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        // Nuestra lista en memoria (Data de prueba)
        public static List<Categoria> categorias = new List<Categoria>()
        {
            new Categoria { Id = 1, Nombre = "Categoria 1" },
            new Categoria { Id = 2, Nombre = "Categoria 2" }
        };

        // 1. LEER TODO (El que ya tienes listo)
        [HttpGet]
        public ActionResult<List<Categoria>> Get()
        {
            return Ok(categorias);
        }

        // 2. CREAR (POST)
        [HttpPost]
        public ActionResult Post([FromBody] Categoria nuevaCategoria)
        {
            categorias.Add(nuevaCategoria);
            return Ok("Categoría agregada con éxito.");
        }

        // 3. ACTUALIZAR (PUT)
        [HttpPut]
        public ActionResult Put([FromBody] Categoria categoriaActualizada)
        {
            var categoriaExistent = categorias.FirstOrDefault(c => c.Id == categoriaActualizada.Id);
            if (categoriaExistent == null)
            {
                return NotFound("Categoría no encontrada.");
            }

            categoriaExistent.Nombre = categoriaActualizada.Nombre;
            return Ok("Categoría actualizada con éxito.");
        }

        // 4. ELIMINAR (DELETE)
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var categoria = categorias.FirstOrDefault(c => c.Id == id);
            if (categoria == null)
            {
                return NotFound("Categoría no encontrada.");
            }

            categorias.Remove(categoria);
            return Ok("Categoría eliminada con éxito.");
        }
    }
}