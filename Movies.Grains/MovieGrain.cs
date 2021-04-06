using Movies.Contracts;
using Orleans;
using Orleans.Providers;
using System.Threading.Tasks;

namespace Movies.Grains
{
	[StorageProvider(ProviderName = "Default")]
	public class MovieGrain : Grain<MovieDataModel>, IMovieGrain
	{
		public Task<MovieDataModel> Get()
			=> Task.FromResult(State);

		public Task Set(string name)
		{
			State = new MovieDataModel { Id = this.GetPrimaryKeyString(), Title = name };
			return Task.CompletedTask;
		}
	}
}