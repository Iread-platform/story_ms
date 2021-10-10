namespace iread_story.Web.Dto.Interaction
{
    public class AudioDto
    {
        public int AudioId { get; set; }
        public InnerInteractionDto Interaction { get; set; }
        public int AttachmentId { get; set; }
    }
}