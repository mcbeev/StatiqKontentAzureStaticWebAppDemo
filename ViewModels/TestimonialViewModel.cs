using System;
using System.Linq;

namespace StatiqTutorial
{
    public class TestimonialViewModel
    {
        public string Author { get; private set; }

        public string Content { get; private set; }

        public DateTime? Date {get; private set;}

        /// <summary>
        /// Contructor for transforming Testimonial content item into the view model
        /// </summary>
        /// <param name="testimonial"></param>
        public TestimonialViewModel(Testimonial testimonial)
        {
            Author = testimonial.Author;
            Content = testimonial.Content.ToString();
            Date = testimonial.Date.Value;
        }        
    }
}
