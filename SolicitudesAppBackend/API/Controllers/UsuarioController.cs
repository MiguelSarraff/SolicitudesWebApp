using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entidades;
using Models.DTOs;
using System.Security.Cryptography;
using System.Text;
using Models;
using Data.Interfaces;
using Microsoft.AspNetCore.Authorization;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : BaseApiController
    {
        private readonly ApplicationDbContext _db;
        private readonly ITokenServicio _tokenServicio;

        public UsuarioController(ApplicationDbContext db, ITokenServicio tokenServicio)
        {
            _db = db;
            _tokenServicio = tokenServicio;
        }

        [Authorize]
        [HttpGet] // api/usuario
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios() 
        {
            var usuarios =await _db.Usuarios.ToListAsync();
            return Ok(usuarios);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario =await _db.Usuarios.FindAsync(id);
            return Ok(usuario);
        }

        [HttpPost("Registro")]

        public async Task<ActionResult<UsuarioDto>> Registro(RegistroDto registroDto) 
        {
            if (await UsuarioExiste(registroDto.Username)) return BadRequest("Username ya esta registrado");

            using var hmac = new HMACSHA512();
            var usuario = new Usuario
            {
                Username = registroDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registroDto.Password)),
                PasswordSalt = hmac.Key    

            };

            _db.Usuarios.Add(usuario);
            await _db.SaveChangesAsync();
            return new UsuarioDto
            {
                Username = registroDto.Username,
                Token = _tokenServicio.CrearToken(usuario)
            };
        }


        [HttpPost("login")]
        public async Task<ActionResult<UsuarioDto>> Login(LoginDto loginDto)
        {
            var usuario = await _db.Usuarios.SingleOrDefaultAsync(x => x.Username == loginDto.Username);
            if (usuario == null) return Unauthorized("Usuario no valido");
            using var hmac = new HMACSHA512(usuario.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
            for (int i = 0; i < computedHash.Length; i++) 
            {
                if (computedHash[i] != usuario.PasswordHash[i]) return Unauthorized("Password no valido");
            }
            return new UsuarioDto
            {
                Username = loginDto.Username,
                Token = _tokenServicio.CrearToken(usuario)
            };
        }

        private async Task<bool> UsuarioExiste(string username)
        {
            return await _db.Usuarios.AnyAsync(u => u.Username == username.ToLower());
        }
    }
}
