using Microsoft.AspNetCore.Mvc;
using PuzzleGame.Business.Abstract;
using PuzzleGame.Entities.Concrate;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PuzzleGame.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUsersService _userService;

        public UserController(IUsersService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public IEnumerable<Users> GetUser()
        {
            return _userService.GetAllAsync().Result.ToArray();
        }
        [HttpPost]
        public async Task<IEnumerable<Users>> PostUser(Users user)
        {
            await _userService.CreateAsync(user);
            return _userService.GetAllAsync().Result.ToArray();
        }
    }
}
