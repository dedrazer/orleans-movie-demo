using Movies.Grains;
using NUnit.Framework;

namespace Movies.Test
{
	/// <summary>
	/// given a movie which exists
	///		then that movie must be returned
	///	given a movie which does not exist
	///		then return must be null
	/// </summary>
	public class TestGet
	{
		private static long _id;
		private static MovieGrain _movieGrain = new MovieGrain();

		[TestFixture]
		public class given_a_movie_which_exists
		{
			public given_a_movie_which_exists()
			{
				_id = 1;
			}

			[Test]
			public void then_that_movie_must_be_returned() => Assert.AreEqual(_movieGrain.Get(_id).Result.Id, 1);
		}

		[TestFixture]
		public class given_a_movie_which_doesnt_exist
		{
			public given_a_movie_which_doesnt_exist()
			{
				_id = 48;
			}

			[Test]
			public void then_return_must_be_null() => Assert.IsNull(_movieGrain.Get(_id).Result);
		}
	}
}