using Movies.Contracts;
using Orleans;
using System.Threading.Tasks;

namespace Movies.GrainClients
{
	public class MovieGrainClient : IMovieGrainClient
	{
		private readonly IGrainFactory _grainFactory;

		public MovieGrainClient(
			IGrainFactory grainFactory
		)
		{
			_grainFactory = grainFactory;
		}

		public Task<MovieDataModel> Get(string id)
		{
			var grain = _grainFactory.GetGrain<IMovieGrain>(id);
			return grain.Get();
		}

		public Task<MovieDataModel[]> GetTop(int amount)
		{
			var grain = _grainFactory.GetGrain<IMovieGrain>("1");
			return grain.GetTop(amount);
		}

		public Task Set(string key, string name)
		{
			var grain = _grainFactory.GetGrain<IMovieGrain>(key);
			return grain.Set(name);
		}
	}
}