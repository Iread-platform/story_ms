using System;
using System.Collections.Generic;
using iread_story.Web.DTO.Review;
using iread_story.Web.DTO.Tag;
using Microsoft.AspNetCore.Http;

namespace iread_story.Web.DTO.Story
{
    public class SearchedStoryDto
    {

        public int StoryId { get; set; }
        public AttachmentDTO StoryCover { get; set; }
        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int StoryLevel { get; set; }

        public string Writer { get; set; }

        public StoryReview Rating { get; set; }
    }
}