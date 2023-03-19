using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using PuzzleGame.Entities.Concrate;
using PuzzleGame.DataAcess.Abstract;

namespace PuzzleGame.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private IUsersDal _usersDal;
        public UserController(IUsersDal usersDal)
        {
            _usersDal = usersDal;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IEnumerable<Users> Get()
        {
            var users = new Users();
          return _usersDal.GetAllAsync().Result;
        }
    }
}
