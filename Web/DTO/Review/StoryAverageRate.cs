using System.Collections.Generic;


namespace iread_story.Web.DTO.Review
{
    public class StoryAverageRate
    {
        public double AverageOfRates { get; set; }
        public int ReviewsCount { get; set; }
        public List<RevieWithUserDto> Reviews { get; set; }
    }
}