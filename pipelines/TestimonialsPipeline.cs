using Kentico.Kontent.Delivery.Abstractions;
using Kontent.Statiq;
using Statiq.Common;
using Statiq.Core;
using Statiq.Razor;

namespace StatiqTutorial
{
    public class TestimonialsPipeline : Pipeline
    {
        public TestimonialsPipeline(IDeliveryClient client)
        {
            InputModules = new ModuleList
            {
                new Kontent<Testimonial>(client),
                    
                // Set the output path for each article
                new SetDestination(Config.FromDocument((doc, ctx)
                    => new NormalizedPath( $"testimonial/{doc.AsKontent<Testimonial>().System.Codename}.html"))),
            };

            ProcessModules = new ModuleList {
                new MergeContent(
                    new ReadFiles(patterns: "_Testimonial.cshtml")
                    ),

                new RenderRazor().WithModel(Config.FromDocument((doc, ctx) =>
                    new TestimonialViewModel(doc.AsKontent<Testimonial>()
                ))),
            };

            OutputModules = new ModuleList {
                new WriteFiles(),
            };
        }
    }
}