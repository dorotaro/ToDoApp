using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace Persistence.Configuration
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddSqlClients(configuration)
                .AddHttpClients(configuration)
                .AddRepositories();
        }

        private static IServiceCollection AddSqlClients(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("ConnectionStrings")["SqlConnectionString"];

            return services
                .AddTransient<ISqlClient>(_ => new SqlClient(connectionString));
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                    .AddSingleton<IToDosRepository, ToDosRepository>();                   
        }

        private static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {

            var apiKey = configuration.GetSection("FireBaseConnectionStrings")["ApiKey"];

            services.AddTransient<HttpClient>();
/*
            services.AddHttpClient<IFirebaseClient, FirebaseClient>(c =>
                c.BaseAddress = new Uri("https://identitytoolkit.googleapis.com/v1"));

            services.AddHttpClient<IFirebaseClient, FirebaseClient>(c =>
                c.DefaultRequestHeaders.Add("key", apiKey));
*/
            return services;

        }
    }
}
