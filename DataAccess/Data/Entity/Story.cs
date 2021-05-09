using System;

namespace iread_story.DataAccess.Data.Entity
{
    public class Story
    {
        public int StoryId { get; set; }

        public string title { get; set; }

        public DateTime ReleaseDate { get; set; }
        
    }
}
