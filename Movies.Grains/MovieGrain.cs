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
		private const string moviesJson = "../Movies.Grains/movies.json";
		/// <summary>
		/// movies saved to memories
		/// </summary>
		private static IEnumerable<MovieDataModel> _persistedMovies;

		/// <summary>
		/// get movie by id
		/// </summary>
		/// <returns>movie</returns>
		public Task<MovieDataModel> Get(long id)
		{
			var res = getMoviesFromJson().FirstOrDefault(x => x.Id == id);

			return Task.FromResult(res);
		}

		/// <summary>
		/// get all movies
		/// </summary>
		/// <returns>all movies</returns>
		public Task<MovieDataModel[]> All() => Task.FromResult(getMoviesFromJson().ToArray());

		/// <summary>
		/// gets N top rated movies
		/// </summary>
		/// <param name="amount">N</param>
		/// <returns>top rated movies in descending order</returns>
		public Task<MovieDataModel[]> GetTop(int amount)
		{

			var res = getMoviesFromJson().OrderByDescending(x => x.Rate).Take(amount).ToArray();

			return Task.FromResult(res);
		}

		/// <summary>
		/// create a new movie with the specified name and rate
		/// </summary>
		/// <returns>the new record</returns>
		public Task<MovieDataModel> Create(MovieDataModel movie)
		{
			var movies = getMoviesFromJson();

			var id = movies.OrderByDescending(x => x.Id).FirstOrDefault().Id+1;

			movie.Id = id;

			movies = movies.Append(movie);

			writeMoviesToJson(movies);

			return Task.FromResult(movie);
		}

		/// <summary>
		/// update the given movie
		/// </summary>
		/// <param name="movie">movie with id to update</param>
		/// <returns>true on success, otherwise false</returns>
		public Task<bool> Update(long id, MovieDataModel movie)
		{
			var movies = getMoviesFromJson();

			var oldMovie = movies.Where(x => x.Id == id).FirstOrDefault();

			if (oldMovie == null)
			{
				// movie not found
				return Task.FromResult(false);
			}

			// copy properties which aren't null
			PropertyCopier.CopyProperties(movie, oldMovie, false);
			
			// id is readonly
			oldMovie.Id = id;

			// persist
			writeMoviesToJson(movies);

			return Task.FromResult(true);
		}

		/// <summary>
		/// load movies from JSON
		/// </summary>
		/// <returns>IEnumerable of movies</returns>
		private IEnumerable<MovieDataModel> getMoviesFromJson()
		{
			if (_persistedMovies == null)
			{
				var moviesJsonString = File.ReadAllText(moviesJson);

				_persistedMovies = JsonConvert.DeserializeObject<MoviesDataModel>(moviesJsonString).movies;
			}

			return _persistedMovies;
		}

		/// <summary>
		/// write movies to the JSON
		/// </summary>
		/// <param name="movies">the movies to save</param>
		private void writeMoviesToJson(IEnumerable<MovieDataModel> movies)
		{
			var moviesDto = new MoviesDataModel() { movies = movies };
			var moviesJsonString = JsonConvert.SerializeObject(moviesDto);
			File.WriteAllText(moviesJson, moviesJsonString);
		}
	}
}