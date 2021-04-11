using Movies.Grains;
using NUnit.Framework;
using System.Linq;

namespace Movies.Test
{
	/// <summary>
	/// given a request for more movies than there are
	///		then all existing movies must be returned in descending order
	///	given a normal request
	///		then N movies must be returned in descending order
	/// </summary>
	public class TestGetTop
	{
		private static int _amount;
		private static MovieGrain _movieGrain = new MovieGrain();

		[TestFixture]
		public class given_a_request_for_more_movies_than_there_are
		{
			public given_a_request_for_more_movies_than_there_are()
			{
				_amount = 50;
			}

			[Test]
			public void then_all_existing_movies_must_be_returned_in_descending_order()
			{
				var res = _movieGrain.GetTop(_amount).Result;
				var orderedRes = res.OrderByDescending(x => x.Rate);

				Assert.AreEqual(res.Length, 24);
				Assert.AreEqual(orderedRes, res);
			}
		}

		[TestFixture]
		public class given_a_normal_request
		{
			public given_a_normal_request()
			{
				_amount = 5;
			}

			[Test]
			public void then_N_movies_must_be_returned_in_descending_order()
			{
				var res = _movieGrain.GetTop(_amount).Result;
				var orderedRes = res.OrderByDescending(x => x.Rate);

				Assert.AreEqual(res.Length, _amount);
				Assert.AreEqual(orderedRes, res);
			}
		}
	}
}