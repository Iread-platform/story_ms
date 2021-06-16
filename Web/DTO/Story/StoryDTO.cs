using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace iread_story.Web.DTO.Story
{
    public class StoryDto
    {

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }
          
        public string Description { get; set; }
        
        public int StoryLevel { get; set; }
        
        public string Writer { get; set; }
        
        public ICollection<string> Tags { get; set; }
        public ICollection<IFormFile> Attachments { get; set; }
        
        public float Rating { get; set; }
    }
}