using Movies.Grains;
using NUnit.Framework;

namespace Movies.Test
{
	/// <summary>
	/// all movies must be returned
	/// </summary>
	[TestFixture]
	public class TestAll
	{
		private static MovieGrain _movieGrain = new MovieGrain();

		[Test]
		public void all_movies_must_be_returned() => Assert.AreEqual(_movieGrain.All().Result.Length, 24);
	}
}