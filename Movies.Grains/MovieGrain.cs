using Movies.Contracts;
using Newtonsoft.Json;
using Orleans;
using Orleans.Providers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Grains
{
	[StorageProvider(ProviderName = "Default")]
	public class MovieGrain : Grain<MovieDataModel>, IMovieGrain
	{
		private const string _moviesJson = "movies.json";

		public Task<MovieDataModel> Get()
		{
			var moviesJsonString = File.ReadAllText(_moviesJson);

			var movies = JsonConvert.DeserializeObject<IEnumerable<MovieDataModel>>(moviesJsonString);
			var s = this.GetPrimaryKeyString();
			var res = movies.FirstOrDefault(x => x.Id == this.GetPrimaryKeyString());
			return Task.FromResult(res);
		}

		public Task Set(string name)
		{
			State = new MovieDataModel { Id = this.GetPrimaryKeyString(), Title = name };
			return Task.CompletedTask;
		}
	}
}