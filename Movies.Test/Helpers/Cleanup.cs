using NUnit.Framework;

namespace Movies.Test.Helpers
{
	public class Cleanup
	{

		/// <summary>
		/// restore the JSON file to its default state
		/// </summary>
		[TearDown]
		public void ResetJSON() => JSONHelper.ResetTestJSON();
	}
}
