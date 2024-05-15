using BClaims.Application.Common.Interfaces;
using BClaims.Infrastructure.FileStore;
using BClaims.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BClaims.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IFileStore, FileStore.FileStore>();
            services.AddTransient<IFileWrapper, FileWrapper>();
            services.AddTransient<IDirectoryWrapper, DirectoryWrapper>();
            return services;
        }

    }
}
