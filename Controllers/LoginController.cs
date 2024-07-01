using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpGet]
        public loginObj Get()
        {
            return new loginObj() { logstatus = true };
        }

        [HttpGet("CheckLogin")]
        public loginObj CheckLogin()
        {
            return new loginObj() { logstatus = false };
        }

        [HttpPost("userlogin")]
        public ActionResult<User> Login(UserDto request)
        {
            if(request.Username == "testUser") return Ok(true);
            return BadRequest("Wrong Name");
        }


    }

    public class loginObj
    { 
        public bool logstatus { get; set; }
        public string logingstr { get; set; }
    }

    public class User
    {
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
    }

    public class UserDto
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
