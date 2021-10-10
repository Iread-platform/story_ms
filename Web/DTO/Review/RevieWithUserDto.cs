namespace iread_story.Web.DTO.Review
{
    public class RevieWithUserDto
    {
        public int ReviewId { get; set; }
        public int Rate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AttachmentDTO UserImage { get; set; }
    }
}