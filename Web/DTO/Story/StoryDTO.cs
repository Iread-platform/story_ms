using System;
using System.Collections.Generic;
using iread_story.Web.DTO.Review;
using iread_story.Web.DTO.Tag;
using iread_story.Web.DTO.Category;
using Microsoft.AspNetCore.Http;

namespace iread_story.Web.DTO.Story
{
    public class StoryDto
    {

        public int StoryId { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Description { get; set; }

        public int StoryLevel { get; set; }

        public string Writer { get; set; }

        public List<CreateTagDto> KeyWords { get; set; }

        public InnerCategoryDto Category { get; set; }

        public IFormFile StoryCover { get; set; }

        public IFormFile StoryAudio { get; set; }

        public StoryReview StoryReview { get; set; }
        public string Color { get; set; }


    }
}