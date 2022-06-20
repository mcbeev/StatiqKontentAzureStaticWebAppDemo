using Kentico.Kontent.Delivery.Abstractions;
using Kentico.Kontent.Urls.Delivery.QueryParameters.Filters;
using Kentico.Kontent.Urls.Delivery.QueryParameters;
using Kontent.Statiq;
using Statiq.Common;
using Statiq.Core;
using Statiq.Razor;

namespace StatiqTutorial
{
    public class HomeFromCmsPipeline : Pipeline
    {
        public HomeFromCmsPipeline(IDeliveryClient client)
        {
            Dependencies.AddRange(nameof(TestimonialsPipeline), nameof(HomeFromCmsPipeline));

            InputModules = new ModuleList
            {
                new Kontent<Home>(client).WithQuery(
                    new EqualsFilter("system.codename", "home"),
                    new LimitParameter(1)),

                new SetDestination(
                    new NormalizedPath("index-from-cms.html")
                )
            };

            ProcessModules = new ModuleList {
                new MergeContent(
                    new ReadFiles(patterns: "Home.cshtml")
                    ),

                new RenderRazor().WithModel(Config.FromDocument((document, context) =>
                    new HomeViewModel(document.AsKontent<Home>())
                )),
            };

            OutputModules = new ModuleList {
                new WriteFiles(),
            };
        }
    }
}