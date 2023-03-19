using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using PuzzleGame.Entities.Concrate;
using PuzzleGame.DataAcess.Abstract;
using PuzzleGame.Business.Abstract;

namespace PuzzleGame.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUsersService _userService;

        public UserController(IUsersService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<Entities.Concrate.Users> Get()
        {
            return _userService.GetAllAsync().Result.ToArray();
        }
    }
}
