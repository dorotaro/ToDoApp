using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Configuration;
using Service.Services;

namespace Service
{
    public static class ServiceExtensions
    {
		public static IServiceCollection AddDomain(this IServiceCollection service, IConfiguration configuration)
		{
			return service
				.AddServices()
				.AddPersistenceServices(configuration);
		}
		private static IServiceCollection AddServices(this IServiceCollection service)
		{
			return service
				.AddSingleton<IToDosService, ToDosService>();
				
		}

		private static IServiceCollection AddPersistenceServices(this IServiceCollection service, IConfiguration configuration)
		{
			return service.AddPersistence(configuration);
		}
	}
}
