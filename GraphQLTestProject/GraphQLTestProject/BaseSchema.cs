using GraphQL.Types;
using GraphQL.Utilities;
using System;

namespace GraphQLTestProject
{
    public class BaseSchema : Schema
    {
        public BaseSchema(IServiceProvider provider)
            : base(provider)
        {
            Query = provider.GetRequiredService<BaseQuery>();
            Mutation = provider.GetRequiredService<BaseMutation>();
        }
    }
}
