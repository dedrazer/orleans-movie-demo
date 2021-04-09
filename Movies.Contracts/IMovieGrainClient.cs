using System.Threading.Tasks;

namespace Movies.Contracts
{
	public interface IMovieGrainClient
	{
		Task<MovieDataModel> Get(long id);
		Task<MovieDataModel[]> All();
		Task<MovieDataModel[]> GetTop(int amount);
		Task<MovieDataModel> Create(MovieDataModel movie);
		Task<bool> Update(long id, MovieDataModel movie);
	}
}
