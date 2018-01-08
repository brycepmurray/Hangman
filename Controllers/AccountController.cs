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
             return _db.Register(creds);
        }
        [HttpPost("login")]
    
      public async Task<UserReturnModel> Login([FromBody]LoginUserModel creds)
        {
            return _db.Login(creds);
        }
    }
}
