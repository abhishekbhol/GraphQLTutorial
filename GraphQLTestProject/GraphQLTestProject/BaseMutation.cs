using GraphQL;
using GraphQL.Types;
using GraphQLTestProject.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLTestProject
{
    public class BaseMutation : ObjectGraphType
    {
        public BaseMutation(Data data)
        {
            Name = "Mutation";

            Field<PlayerType>(
                "createHuman",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PlayerType>> { Name = "player" }
                ),
                resolve: context =>
                {
                    var p = context.GetArgument<Player>("player");
                    return data.AddPlayer(p);
                });
        }
    }
}
