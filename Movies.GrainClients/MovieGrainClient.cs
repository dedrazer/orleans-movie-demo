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

		public Task<MovieDataModel> Get(long id)
		{
			var grain = _grainFactory.GetGrain<IMovieGrain>(id.ToString());
			return grain.Get(id);
		}

		public Task<MovieDataModel[]> All()
		{
			var grain = _grainFactory.GetGrain<IMovieGrain>("0");
			return grain.All();
		}

		public Task<MovieDataModel[]> GetTop(int amount)
		{
			var grain = _grainFactory.GetGrain<IMovieGrain>("0");
			return grain.GetTop(amount);
		}
		public Task<MovieDataModel> Create(MovieDataModel movie)
		{
			var grain = _grainFactory.GetGrain<IMovieGrain>("0");
			return grain.Create(movie);
		}

		public Task Set(string key, string name)
		{
			var grain = _grainFactory.GetGrain<IMovieGrain>(key);
			return grain.Set(name);
		}
	}
}