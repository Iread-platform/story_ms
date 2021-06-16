using System.Collections.Generic;
using iread_story.DataAccess.Data.Entity;

namespace iread_story.DataAccess.Interface
{
    public interface IStory
    {
        Story GetStory(int id);

        void UpdateStory(int id, Story story);
        void AddStory( Story story);

        IEnumerable<Story> GetStories();

        void DeleteStory(int id);

        bool Exists(int id);
        
        IEnumerable<Story> GetStoriesByIds(List<int> ids);
        

    }
}