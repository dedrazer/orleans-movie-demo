using System.IO;

namespace Movies.Test.Helpers
{
	public class JSONHelper
	{
		private const string moviesJson = "../Movies.Grains/movies.json";
		private const string defaultMoviesJson = "../Movies.Grains/defaultMovies.json";

		public static void ResetTestJSON()
		{
			var s = File.ReadAllText(defaultMoviesJson);
			File.WriteAllText(moviesJson, s);
		}
	}
}
