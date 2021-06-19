using System;

namespace iread_story.Web.DTO
{
    public class AttachmentDTO
    {
        public string Name { get; set; }
        public string DownloadUrl { get; set; }
        public string Type { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }
        public DateTime UploadDate { get; set; }
    }
}