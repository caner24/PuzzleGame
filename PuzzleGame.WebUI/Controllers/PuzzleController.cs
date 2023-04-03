using Microsoft.AspNetCore.Mvc;
using PuzzleGame.Business.Abstract;
using PuzzleGame.Business.Concrate;
using PuzzleGame.Entities.Concrate;
using System.Collections.Generic;

namespace PuzzleGame.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PuzzleController : Controller
    {

        private IPuzzleService _puzzleService;
        public PuzzleController(IPuzzleService puzzleService)
        {
            _puzzleService = puzzleService;
        }

        [HttpGet]
        public IEnumerable<Puzzless> GetPuzzle()
        {
            return _puzzleService.GetAllAsync().Result.ToArray();
        }
    }
}
