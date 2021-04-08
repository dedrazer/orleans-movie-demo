using Orleans;
using System.Threading.Tasks;

namespace Movies.Contracts
{
	public interface IMovieGrain : IGrainWithStringKey
	{
		Task<MovieDataModel> Get(long id);
		Task<MovieDataModel[]> All();
		Task<MovieDataModel[]> GetTop(int amount);
		Task<MovieDataModel> Create(MovieDataModel movie);
		Task Set(string name);
	}
}