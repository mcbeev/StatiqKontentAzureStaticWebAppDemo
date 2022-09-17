using System.Linq;

namespace StatiqTutorial
{
    public class HomeViewModel
    {
        public string Title { get; private set; }

        public string Content { get; private set; }

        public string SourceDescription { get;set; }

        public string HeroImageUrl { get; private set; }
        public int HeroImageHeight { get; private set; }

        public int HeroImageWidth { get; private set; }

        /// <summary>
        /// Contructor for transforming Home content item into the view model
        /// </summary>
        /// <param name="home"></param>
        public HomeViewModel(Home home)
        {
            Title = home.Title;
            Content = home.Content;
            if (home.HeroImage != null)
            {
                var kontentAsset = home.HeroImage.First();
                HeroImageUrl = kontentAsset.Url;
                HeroImageHeight = kontentAsset.Height;
                HeroImageWidth = kontentAsset.Width;
            }
            SourceDescription = "Content on this page is fetched from <b><a href=\"https://kontent.ai\" target=\"_blank\">Kontent.ai</a></b> Headless CMS via API at build time. This home page has its counterpart on <a href=\"/index.html\">index</a> route.";
        }

        public HomeViewModel(string title, string content)
        {
            Title = title;
            Content = content;
            HeroImageUrl = "https://via.placeholder.com/150";
            HeroImageHeight = 150;
            HeroImageWidth = 150;            
            SourceDescription = "Content on this page is from local markdown file. This home page has its counterpart on <a href=\"/index-from-cms.html\">index-from-cms</a> route.";
        }
    }
}