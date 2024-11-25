using Business.IService;
using Business.Service;
using Core.Security.JWT;
using Items.Types;

namespace Api.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<IServiceBase, ServiceBase>(); 
            services.AddTransient<ITokenHelper, JwtHelper>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IContextAccessor, ContextAccessor>();

            var builders = typeof(IServiceBase).Assembly
                                                 .GetTypes()
                                                 .Where(t => t.GetInterfaces()
                                                              .Any(i => i.Name == typeof(IServiceBase).Name) && t.IsClass);

            foreach (var builder in builders)
            {
                var builderInterface = builder.GetInterfaces()
                                            .Where(x => x.Name.Contains(builder.Name))
                                            .FirstOrDefault();

                if (builderInterface == null)
                {
                    throw new Exception($"Base class did not found for type: {builder.FullName}");
                }

                services.AddTransient(builderInterface, builder);
            }

            return services;
        }

        public static IServiceCollection AddOptions(this IServiceCollection services)
        {
            IConfiguration configuration;

            using (var serviceProvider = services.BuildServiceProvider())
            {
                configuration = serviceProvider.GetService<IConfiguration>();
            }

            services.Configure<TokenOptions>(configuration.GetSection("TokenOptions"));
            return services;
        }

    }
}
