using Kentico.Kontent.Delivery.Abstractions;
using Kentico.Kontent.Delivery.Urls.QueryParameters;
using Kentico.Kontent.Delivery.Urls.QueryParameters.Filters;
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
                    new HomeViewModel(document.AsKontent<Home>()
                ))),
            };

            OutputModules = new ModuleList {
                new WriteFiles(),
            };
        }
    }
}