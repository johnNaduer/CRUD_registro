using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Asegúrate de que el espacio de nombres sea correcto


namespace MiProyectoBackend.Controllers // Asegúrate de que el espacio de nombres sea correcto
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public ActionResult<IEnumerable<Usuarios>> GetUsuarios() // Cambiado a "Usuario" si esa es la clase correcta
        {
            var usuarios = _context.Usuarios.ToList(); // Cambiado a "_context.Usuarios" si es la propiedad correcta
            return Ok(usuarios);
        }

        // POST: api/Usuarios
        [HttpPost]
        public IActionResult PostUsuario([FromBody] Usuarios usuario)
        {
            if (usuario == null)
            {
                return BadRequest("El usuario es nulo");
            }

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

             return Ok(usuario);
        }

         // PUT: api/Usuarios/5 (Donde 5 es el ID del usuario a actualizar)
        [HttpPut("{id}")]
        public IActionResult PutUsuario(int id, [FromBody] Usuarios usuario)
        {
            if (usuario == null || usuario.Id != id)
            {
                return BadRequest("Datos inválidos");
            }

            var usuarioExistente = _context.Usuarios.FirstOrDefault(u => u.Id == id);

            if (usuarioExistente == null)
            {
                return NotFound("Usuario no encontrado");
            }

            // Actualiza los datos del usuario existente con los nuevos valores
            usuarioExistente.Nombre = usuario.Nombre;
            usuarioExistente.Clave = usuario.Clave;

            _context.SaveChanges();

            return Ok(usuarioExistente);
        }

        // DELETE: api/Usuarios/5 (Donde 5 es el ID del usuario a eliminar)
        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            var usuarioExistente = _context.Usuarios.FirstOrDefault(u => u.Id == id);

            if (usuarioExistente == null)
            {
                return NotFound("Usuario no encontrado");
            }

            _context.Usuarios.Remove(usuarioExistente);
            _context.SaveChanges();

            return Ok(new { message = "Usuario eliminado correctamente" });
        }
    }
}

