using System;

namespace iread_story.Web.DTO.Category
{
    public class InnerCategoryDto
    {
        public int CategoryId { get; set; }
        public String Title { get; set; }
        public Nullable<int> Rank { get; set; }

    }
}