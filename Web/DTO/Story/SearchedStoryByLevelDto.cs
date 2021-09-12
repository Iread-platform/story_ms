using System;
using System.Collections.Generic;
using iread_story.Web.DTO.Review;
using iread_story.Web.DTO.Tag;
using Microsoft.AspNetCore.Http;

namespace iread_story.Web.DTO.Story
{
    public class SearchedStoryByLevelDto : GenericStoryDto
    {

        public int StoryLevel { get; set; }
        public string Writer { get; set; }
        public string Color { get; set; }


    }
}