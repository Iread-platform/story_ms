using System.Collections.Generic;
using iread_story.Web.DTO.Tag;

namespace iread_story.Web.Utils
{
    public class TagsWithStoryId
    {
        public List<CreateTagDto> tagsDtos { get; set; }
        public int storyId { get; set; }
    }
}