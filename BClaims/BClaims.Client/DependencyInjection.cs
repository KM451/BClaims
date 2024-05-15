using BClaims.Client.HttpRepository;
using BClaims.Client.HttpRepository.Interfaces;
using Radzen;

namespace BClaims.Client
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddClient(this IServiceCollection services, Uri uri)
        {
            services.AddHttpClient("BClaimsApi", client =>
            {
                client.BaseAddress = uri;
                client.Timeout = TimeSpan.FromSeconds(5);
            });

            services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("BClaimsApi"));

            services.AddScoped<IReportsHttpRepository, ReportsHttpRepository>();
            services.AddScoped<IAttachmentRepository, AttachmentRepository>();

            //services.AddRadzenComponents();
   
           
            return services;
        }
    }
}
