using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iread_story.DataAccess.Data;
using iread_story.DataAccess.Data.Entity;
using iread_story.DataAccess.Interface;
using Microsoft.EntityFrameworkCore;

namespace iread_story.DataAccess.Repository
{
    public class StoryRepository : IStoryRepository
    {
        private readonly AppDbContext _context;

        public StoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Story> GetStory(int id)
        {
            return await _context.Stories.Include(s => s.Pages).Where(s => s.StoryId == id).FirstAsync();
        }

        public void UpdateStory(int id, Story story)
        {
            _context.Attach(story);
            _context.Stories.Update(story);
            _context.SaveChanges();
        }

        public void AddStory(Story story)
        {
            _context.Stories.Add(story);
            _context.SaveChangesAsync();
        }

        public List<Story> GetStories()
        {
            return _context.Stories.ToList();
        }

        public void DeleteStory(int id)
        {
            var storyToRemove = new Story() { StoryId = id };
            _context.Stories.Attach(storyToRemove);
            _context.Stories.Remove(storyToRemove);
            _context.SaveChanges();
        }

        public bool Exists(int id)
        {
            return _context.Stories.Any(story => story.StoryId.Equals(id));
        }

        public List<Story> GetStoriesByIds(List<int> ids)
        {
            return _context.Stories.Where(story => ids.Contains(story.StoryId)).ToList();
        }
    }
}