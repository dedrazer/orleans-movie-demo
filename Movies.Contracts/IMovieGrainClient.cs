using System.Threading.Tasks;

namespace Movies.Contracts
{
	public interface IMovieGrainClient
	{
		Task<MovieDataModel> Get(string id);
		Task<MovieDataModel[]> GetTop(int amount);
		Task Set(string key, string name);
	}
}
