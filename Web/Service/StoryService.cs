using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iread_story.DataAccess.Data;
using iread_story.DataAccess.Data.Entity;
using iread_story.DataAccess.Interface;
using Microsoft.EntityFrameworkCore;

namespace iread_story.Web.Service
{
    public class StoryService
    {
        private readonly IPublicRepository _repository;

        public StoryService(IPublicRepository repository)
        {
            _repository = repository;
        }

        public async Task<Story> GetStory(int id)
        {
            return await _repository.GetStoryService.GetStory(id);
        }

        public bool UpdateStory(int id, Story story)
        {
            try
            {
                _repository.GetStoryService.UpdateStory(id, story);
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public bool AddStory(Story story)
        {
            try
            {
                _repository.GetStoryService.AddStory(story);
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public List<Story> GetStories()
        {
            return _repository.GetStoryService.GetStories();
        }

        public bool DeleteStory(int id)
        {
            try
            {
                _repository.GetStoryService.DeleteStory(id);
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public bool Exists(int id)
        {
            return _repository.GetStoryService.Exists(id);
        }

        public List<Story> GetStoriesByIds(List<int> ids)
        {
            return _repository.GetStoryService.GetStoriesByIds(ids);
        }

        internal async Task<List<Story>> GetByTitle(string title)
        {
            return await _repository.GetStoryService.GetByTitle(title);
        }

        internal async Task<List<Story>> GetByLevel(int level)
        {
            return await _repository.GetStoryService.GetByLevel(level);
        }
    }
}