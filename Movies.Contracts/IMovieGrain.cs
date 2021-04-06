using Orleans;
using System.Threading.Tasks;

namespace Movies.Contracts
{
	public interface IMovieGrain : IGrainWithStringKey
	{
		Task<MovieDataModel> Get();
		Task Set(string name);
	}
}