using Microsoft.AspNetCore.Mvc;
using Movies.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Movies.Server.Controllers
{
	[Route("api/[controller]")]
	public class MovieController : Controller
	{
		private readonly IMovieGrainClient _client;

		public MovieController(
			IMovieGrainClient client
		)
		{
			_client = client;
		}

		// GET api/movies/1
		[HttpGet("{id}")]
		public async Task<MovieDataModel> Get(string id)
		{
			var result = await _client.Get(id).ConfigureAwait(false);
			return result;
		}

		// SET api/movies/top/10
		[HttpGet("top/{amount}")]
		public async Task<IEnumerable<MovieDataModel>> GetTop(int amount)
		{
			var result = await _client.GetTop(amount).ConfigureAwait(false);
			return result;
		}

		// POST api/my/1234
		[HttpPost("{id}")]
		public async Task Set([FromRoute] string id, [FromForm] string name)
			=> await _client.Set(id, name).ConfigureAwait(false);
	}
}