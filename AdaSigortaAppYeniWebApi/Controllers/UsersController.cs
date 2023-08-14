using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdaSigortaAppYeniWebApi.Data;
using AdaSigortaAppYeniWebApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AdaSigortaAppYeniWebApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        private readonly IConfiguration _configuration;

        
        public UsersController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        // GET: api/Users
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [AllowAnonymous]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
          if (_context.Users == null)
          {
              return Problem("Entity set 'AppDbContext.Users'  is null.");
          }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
        }


        [HttpGet("login/{email}/{password}")]
        public async Task<ActionResult<User>> Login(string email, string password)
        {
            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
            {

                var user = await _context.Users.Where(x => x.Email!.Equals(email) && x.Password == password).FirstOrDefaultAsync();

                return user != null ? Ok(user) : NotFound();

            }
            return BadRequest();
        }

     

        [AllowAnonymous]
        [HttpPost("loginJwt")]
        public IActionResult LoginJwt([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid || request == null)
            {
                return BadRequest("Invalid request data.");
            }

            var user = _context.Users.FirstOrDefault(x => x.Email == request.Email && x.Password == request.Password);

            if (user != null)
            {
                var token = GenerateJwtToken(user);
                return Ok(new AuthenticateUser { Token = token, user = user });
            }
            else
            {
                return Unauthorized("Invalid email or password.");
            }
        }


        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]); 
                
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()), 

                }),
                Audience = _configuration["Token:Audience"],
                Issuer = _configuration["Token:Issuer"],
                Expires = DateTime.UtcNow.AddDays(15), 
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return  tokenHandler.WriteToken(token);
        }

        
    }
    }

