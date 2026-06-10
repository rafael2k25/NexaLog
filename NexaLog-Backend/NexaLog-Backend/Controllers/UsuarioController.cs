using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NexaLog_Backend.Data;
using NexaLog_Backend.Models;

namespace NexaLog_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly NexaLogContext _context;

        public UsuarioController(NexaLogContext context)
        {
            _context = context;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
                return NotFound();

            return usuario;
        }

        // POST: api/Usuario/cadastro
        [HttpPost("cadastro")]
        public async Task<ActionResult<Usuario>> Cadastro(Usuario usuario)
        {
            var emailExiste = await _context.Usuarios
                .AnyAsync(u => u.Email == usuario.Email);

            if (emailExiste)
            {
                return BadRequest("Este e-mail já está cadastrado.");
            }

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok("Usuário cadastrado com sucesso.");
        }

        // POST: api/Usuario/login
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginRequest login)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u =>
                    u.Email == login.Email &&
                    u.Senha == login.Senha);

            if (usuario == null)
            {
                return Unauthorized("E-mail ou senha inválidos.");
            }

            return Ok(new
            {
                mensagem = "Login realizado com sucesso",
                idUsuario = usuario.IdUsuario,
                nome = usuario.Nome,
                tipoUsuario = usuario.TipoUsuario
            });
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;

        public string Senha { get; set; } = string.Empty;
    }
}