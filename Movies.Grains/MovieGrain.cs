using Movies.Contracts;
using Newtonsoft.Json;
using Orleans;
using Orleans.Providers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Grains
{
	[StorageProvider(ProviderName = "Default")]
	public class MovieGrain : Grain<MovieDataModel>, IMovieGrain
	{
		private const string _moviesJson = "../Movies.Grains/movies.json";

		public Task<MovieDataModel> Get()
		{
			var moviesJsonString = File.ReadAllText(_moviesJson);

			var movies = JsonConvert.DeserializeObject<MoviesDataModel>(moviesJsonString).movies;
			var res = movies.FirstOrDefault(x => x.Id.ToString() == this.GetPrimaryKeyString());

			return Task.FromResult(res);
		}

		public Task<MovieDataModel[]> GetTop(int amount)
		{
			var moviesJsonString = File.ReadAllText(_moviesJson);

			var movies = JsonConvert.DeserializeObject<MoviesDataModel>(moviesJsonString).movies;

			var res = movies.OrderByDescending(x => x.Rate).Take(amount).ToArray();

			return Task.FromResult(res);
		}

		public Task Set(string name)
		{
			State = new MovieDataModel { Id = this.GetPrimaryKeyLong(), Name = name };
			return Task.CompletedTask;
		}
	}
}