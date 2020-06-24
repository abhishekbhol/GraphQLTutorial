using GraphQL.Types;
using GraphQLTestProject.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLTestProject
{
    public class BaseQuery : ObjectGraphType<object>
    {
        public BaseQuery(Data dataLayer)
        {
            Name = "Query";


            Field<PlayerType>(
                "playerInfo",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id"}
                ),
                resolve: context => dataLayer.GetPlayerById(context.GetArgument<int>("id")));

        }
    }
}
