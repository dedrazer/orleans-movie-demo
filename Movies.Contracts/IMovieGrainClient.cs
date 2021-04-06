using System.Threading.Tasks;

namespace Movies.Contracts
{
	public interface IMovieGrainClient
	{
		Task<MovieDataModel> Get(string id);
		Task Set(string key, string name);
	}
}
