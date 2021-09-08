using System;
using System.Collections.Generic;

namespace iread_story.Web.DTO.Category
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public String Title { get; set; }
        public Nullable<int> Rank { get; set; }
        public List<InnerCategoryDto> SubCategories { get; set; }

    }
}