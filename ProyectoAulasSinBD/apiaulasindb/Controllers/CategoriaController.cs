using apiaulasindb.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiaulasindb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        // Corrección: Inicialización correcta de la lista con asignación (=) y llaves correspondientes
        public static List<Categoria> categorias = new List<Categoria>()
        {
            new Categoria { Id = 1, Nombre = "Categoria 1" },
            new Categoria { Id = 2, Nombre = "Categoria 2" }
        };

        // El método Get ahora está DENTRO de la clase CategoriaController
        [HttpGet]
        public ActionResult<List<Categoria>> Get()
        {
            return Ok(categorias);
        }
    }
}
