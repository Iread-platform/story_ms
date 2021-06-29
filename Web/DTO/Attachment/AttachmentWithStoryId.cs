using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace iread_story.Web.DTO
{
    public class AttachmentsWithStoryId
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }   
}