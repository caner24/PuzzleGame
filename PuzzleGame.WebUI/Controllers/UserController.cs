using Microsoft.AspNetCore.Mvc;
using PuzzleGame.Business.Abstract;
using System.Collections.Generic;

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
		public IEnumerable<Entities.Concrate.Users> Get()
		{
			return _userService.GetAllAsync().Result.ToArray();
		}
	}
}
