using Movies.Contracts;
using Movies.Grains;
using Movies.Test.Helpers;
using NUnit.Framework;

namespace Movies.Test
{
	/// <summary>
	/// given a model with an existing id
	///		then id must be automatically generated
	/// </summary>
	public class TestCreate
	{
		// input
		private static MovieDataModel _movie = new MovieDataModel()
		{
			Id = 0,
			Name = "Johnny English",
			Rate = "10.0"
		};

		// process
		private static MovieGrain _movieGrain = new MovieGrain();

		// output
		private static MovieDataModel _res;

		[TestFixture]
		public class given_a_model_with_an_existing_id : Cleanup
		{
			public given_a_model_with_an_existing_id()
			{
				_movie.Id = 10;
				_res = _movieGrain.Create(_movie).Result;
			}

			[Test]
			public void then_id_must_be_automatically_generated() => Assert.Greater(_res.Id, 0);
		}
	}
}