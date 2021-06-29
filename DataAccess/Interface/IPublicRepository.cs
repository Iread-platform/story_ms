namespace iread_story.DataAccess.Interface
{
    public interface IPublicRepository
    {
        IStoryRepository GetStoryService { get; }
    }
}