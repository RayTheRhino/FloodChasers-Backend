using FloodChasersModel.Boundaries.Learn;
using FloodChasersModel.Learn.Service;
using Microsoft.AspNetCore.Mvc;

namespace FloodChasersAPI.Controllers
{
    [ApiController]
    [Route("Articles")]
    public class LearnController : ControllerBase
    {
        private ILearnService _learnService;
        public LearnController(ILearnService learnService)
        {
            _learnService = learnService;
        }


        [HttpPost]
        [Route("GetAllArticles")]
        public async Task<List<LearnBoundary>> GetArticles()
        {
            try
            {
                var allArticles = await _learnService.GetAllArticles();
                return allArticles;
            }
            catch (Exception) { throw; }
        }
    }
}

