using FormService.API.Services;

namespace FormService.API.Mapping
{
    public class ServiceConfigurator
    {
        public static void Configure(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<IFormManageService, FormManageService>();

        }
    }
}
