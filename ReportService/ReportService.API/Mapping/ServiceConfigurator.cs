using Microsoft.AspNetCore.Cors.Infrastructure;
using ReportService.API.Services;

namespace ReportService.API.Mapping
{
    public class ServiceConfigurator
    {
        public static void Configure(IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<IFormReportService, FormReportService>();
           
        }
    }
}
