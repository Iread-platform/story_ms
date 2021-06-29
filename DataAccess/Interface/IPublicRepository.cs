namespace iread_story.DataAccess.Interface
{
    public interface IPublicRepository
    {
        IStory getStoryService { get; }
        IPageRepository GetPageRepository { get; }
    }
}