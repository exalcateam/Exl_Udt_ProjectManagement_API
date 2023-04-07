using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Infrastructure;
using TaskManagement.Model;

namespace TaskManagement.Controllers
{

    [Route("api/[Controller]/[action]")]
    public class SignuploginController : ControllerBase
    {
            private readonly DataContext _dbContext;
            public SignuploginController(DataContext dbContext)
            {
                _dbContext = dbContext;
            }
            [HttpPost("authenticate")]
            public async Task<IActionResult> Authenticate([FromBody] Signuplogin logindetials)
            {
                if (logindetials == null)
                    return BadRequest();
                var login = await _dbContext.Signuplogins
                .FirstOrDefaultAsync(x => x.Username == logindetials.Username && x.Password == logindetials.Password);
                if (login == null)
                    return NotFound(new
                    { Message = "User Not Found" });

                return Ok(new
                { Message = "Login Success" });
            }
            [HttpPost("register")]
            public async Task<IActionResult> RegisterUser([FromBody] Signuplogin logindetails)
            {

                if (logindetails == null)
                    return BadRequest();

                await _dbContext.Signuplogins.AddAsync(logindetails);
                await _dbContext.SaveChangesAsync();
                return Ok(new
                { Message = "User Registered!" });

            }

        }
    }
