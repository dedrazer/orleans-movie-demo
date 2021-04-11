using Movies.Contracts;
using Movies.Grains;
using Movies.Test.Helpers;
using NUnit.Framework;

namespace Movies.Test
{
	/// <summary>
	/// given a nonexistent model
	///		then no update must take place
	///	given a valid model
	///		then an update must take place
	///		then movie count must not change
	///		then the null fields must be unchanged
	/// </summary>
	public class TestUpdate
	{
		// input
		private static long _id = 10;
		private static MovieDataModel _movie = new MovieDataModel()
		{
			Id = 10,
			Name = "Johnny Maltese",
			Rate = "4.6"
		};

		// process
		private static MovieGrain _movieGrain = new MovieGrain();
		private static MovieDataModel _originalMovie;
		private static MovieDataModel _updatedMovie;

		// output
		private static bool _res;

		[TestFixture]
		public class given_a_nonexistent_model
		{
			public given_a_nonexistent_model()
			{
				_id = 49;
				_res = _movieGrain.Update(_id, _movie).Result;
			}

			[Test]
			public void then_no_update_must_take_place()
			{
				Assert.IsFalse(_res);
				Assert.AreEqual(_movieGrain.All().Result.Length, 24);
			}
		}

		[TestFixture]
		public class given_a_valid_model : Cleanup
		{
			public given_a_valid_model()
			{
				_id = _movie.Id;
				_originalMovie = _movieGrain.Get(_id).Result;
				_res = _movieGrain.Update(_id, _movie).Result;
			}

			[Test]
			public void then_an_update_must_take_place() => Assert.IsTrue(_res);

			[Test]
			public void then_movie_count_must_not_change() => Assert.AreEqual(_movieGrain.All().Result.Length, 24);

			[Test]
			public void then_the_null_fields_must_be_unchanged()
			{
				_updatedMovie = _movieGrain.Get(_id).Result;

				Assert.AreEqual(_originalMovie.Key, _updatedMovie.Key);
				Assert.AreEqual(_originalMovie.Img, _updatedMovie.Img);
			}
		}
	}
}