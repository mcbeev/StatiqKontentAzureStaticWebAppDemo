using System.Linq;

namespace StatiqTutorial
{
    public class HomeViewModel
    {
        public string Title { get; private set; }

        public string Content { get; private set; }

        public string HeroImageUrl { get; private set; }

        /// <summary>
        /// Contructor for transforming Home content item into the view model
        /// </summary>
        /// <param name="home"></param>
        public HomeViewModel(Home home)
        {
            Title = home.Title;
            Content = home.Content;
            HeroImageUrl = home.HeroImage.First().Url;
        }

        public HomeViewModel(string title, string content)
        {
            Title = title;
            Content = content;
        }
    }
}