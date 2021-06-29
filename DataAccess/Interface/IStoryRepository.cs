using System.Collections.Generic;
using System.Threading.Tasks;
using iread_story.DataAccess.Data.Entity;

namespace iread_story.DataAccess.Interface
{
    public interface IStoryRepository
    {
        Task<Story> GetStory(int id);

        void UpdateStory(int id, Story story, Story oldStory);
        void AddStory( Story story);

        List<Story> GetStories();

        void DeleteStory(int id);

        bool Exists(int id);
        
        List<Story> GetStoriesByIds(List<int> ids);
        

    }
}