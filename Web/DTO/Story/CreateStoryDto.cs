using System;
using System.Collections.Generic;
using iread_story.Web.DTO.Tag;
using Microsoft.AspNetCore.Http;

namespace iread_story.Web.DTO.Story
{
    public class CreateStoryDto
    {
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }
          
        public string Description { get; set; }
        
        public int StoryLevel { get; set; }
        
        public string Writer { get; set; }
        
        public List<CreateTagDto> KeyWords { get; set; }
        
        public IFormFile StoryCover { get; set; }
        public IFormFile StoryAudio { get; set; }
    }
}