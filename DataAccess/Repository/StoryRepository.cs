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
            return await _context.Stories.Include(s => s.Pages).Where(s => s.StoryId == id).SingleOrDefaultAsync();
        }

        public void UpdateStory(Story story)
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

        public List<Story> GetStories(Language? language)
        {
            return language == null ? _context.Stories.ToList() : _context.Stories.Where(s => s.LanguageId == language.LanguageId).ToList();
        }

        public void DeleteStory(Story story)
        {
            _context.Stories.Remove(story);
            _context.SaveChanges();
        }

        public bool Exists(int id)
        {
            return _context.Stories.Any(story => story.StoryId.Equals(id));
        }

        public List<Story> GetStoriesByIds(List<int> ids)
        {
            return _context.Stories.Include(s => s.Pages).Where(story => ids.Contains(story.StoryId)).ToList();
        }

        public async Task<List<Story>> GetByTitle(string title)
        {
            return await _context.Stories.Where(story => story.Title.Contains(title)).ToListAsync();
        }

        public async Task<List<Story>> GetByLevel(int level, Language? language)
        {
            return language == null ? await _context.Stories
            .Where(story => story.StoryLevel <= level).ToListAsync() : await _context.Stories
            .Where(story => story.StoryLevel <= level && story.LanguageId == language.LanguageId).ToListAsync();
        }

        public async Task<List<Story>> GetByIds(List<int> ids)
        {
            return await _context.Stories
            .Where(story => ids.Contains(story.StoryId)).ToListAsync();
        }

    }
}