using GraphQL.Types;
using Movies.Contracts;

namespace Movies.Server.Gql.Types
{
	public class MovieGraphType : ObjectGraphType<MovieDataModel>
	{
		public MovieGraphType()
		{
			Name = "Movie";
			Description = "A movie graphtype.";

			Field(x => x.Id, nullable: true).Description("Unique key.");
			Field(x => x.Name, nullable: true).Description("Name.");
			Field(x => x.Rate, nullable: true).Description("Rating.");
		}
	}
}