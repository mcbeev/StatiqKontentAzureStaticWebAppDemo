using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Kentico.Kontent.Delivery.Abstractions;
using Kentico.Kontent.Delivery.Extensions;
using Statiq.App;
using Statiq.Common;
using Statiq.Web;

namespace StatiqTutorial
{
    class Program
    { 
        public static async Task<int> Main(string[] args) =>
            await Bootstrapper
                .Factory
                .CreateDefault(args)
                .ConfigureServices((services, settings) =>
                {
                    // Registers Kontent Custom Type Provider for strongly typed models
                    services.AddSingleton<ITypeProvider, CustomTypeProvider>();
                    // Registers Kontent's Delivery Client
                    services.AddDeliveryClient((IConfiguration)settings);
                })
                .AddHostingCommands()
                .RunAsync();
    }

}
