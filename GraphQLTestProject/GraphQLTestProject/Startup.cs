using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using GraphQLTestProject.Types;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Security.Claims;

namespace GraphQLTestProject
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.AddCors();

            services.AddSingleton<Data>();
            services.AddSingleton<ISchema, BaseSchema>();
            services.AddSingleton<BaseQuery>();
            services.AddSingleton<BaseMutation>();
            services.AddSingleton<Player>();
            services.AddSingleton<PlayerType>();
            services.AddSingleton<TeamEnum>();

            services.AddLogging(builder => builder.AddConsole());
            services.AddHttpContextAccessor();

            services.AddGraphQL(_ =>
            {
                _.EnableMetrics = true;
                _.ExposeExceptions = true;
            })
            .AddUserContextBuilder(httpContext => new GraphQLUserContextDictionary { User = httpContext.User });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors((builder) =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.Build();
            });
            app.UseGraphQL<ISchema>();
            app.UseGraphQLPlayground();

        }

        public class GraphQLUserContextDictionary : Dictionary<string, object>
        {
            public ClaimsPrincipal? User { get; set; }
        }

    }
}
