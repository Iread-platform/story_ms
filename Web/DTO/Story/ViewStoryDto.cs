using System;
using System.Collections.Generic;
using iread_story.Web.DTO.Category;
using iread_story.Web.DTO.Review;
using iread_story.Web.DTO.Tag;
using Microsoft.AspNetCore.Http;

namespace iread_story.Web.DTO.Story
{
    public class ViewStoryDto
    {
        public int StoryId { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Description { get; set; }

        public int StoryLevel { get; set; }

        public string Writer { get; set; }

        public List<TagWithIdDto> KeyWords { get; set; }
        public InnerCategoryDto Category { get; set; }

        public AttachmentDTO StoryCover { get; set; }
        public AttachmentDTO StoryAudio { get; set; }
        public StoryReview Rating { get; set; }
        public string Color { get; set; }

    }
}