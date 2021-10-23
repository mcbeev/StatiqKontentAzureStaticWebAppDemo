using Statiq.Common;
using Statiq.Core;

namespace StatiqTutorial
{
    public class CopyAssetsPipeline : Pipeline
    {
        public CopyAssetsPipeline()
        {
            InputModules = new ModuleList
            {
                new CopyFiles("./api/**/*", "./*")
            };
        }
    }
}