using System.Collections.Generic;

namespace Movies.Contracts
{
	public class MoviesDataModel
	{
		public IEnumerable<MovieDataModel> movies { get; set; }
	}
}
