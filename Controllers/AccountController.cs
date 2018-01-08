using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using hangman_c.Models;
using hangman_c.Repsoitories;
using Microsoft.AspNetCore.Mvc;

namespace hangman_c.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly UserRepository _db;
        public AccountController(UserRepository repo)
        {
            _db = repo;
        }
        [HttpPost("register")]
        public async Task<UserReturnModel> Register([FromBody]RegisterUserModel creds)
        {
            if(ModelState.IsValid)
            {

            UserReturnModel user = DbContext.Login(creds);
            if(user !=null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, user.Email)
                };
                var userIdentity = new ClaimsIdentity(claims, "login);")
            }
             return _db.Register(creds);
        }
            }
            return null;
    }
        [HttpPost("login")]
    
      public async Task<UserReturnModel> Login([FromBody]LoginUserModel creds)
        {
            return _db.Login(creds);
        }
    }
}
