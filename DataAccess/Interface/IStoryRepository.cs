using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iread_story.DataAccess.Data.Entity;

namespace iread_story.DataAccess.Interface
{
    public interface IStoryRepository
    {
        Task<Story> GetStory(int id);

        void UpdateStory(int id, Story story);
        void AddStory(Story story);

        List<Story> GetStories();

        void DeleteStory(Story story);

        bool Exists(int id);

        List<Story> GetStoriesByIds(List<int> ids);
        public Task<List<Story>> GetByTitle(string title);
        public Task<List<Story>> GetByLevel(int level);
        public Task<List<Story>> GetByIds(List<int> ids);
    }
}