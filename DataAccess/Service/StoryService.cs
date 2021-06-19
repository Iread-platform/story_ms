using System.Collections.Generic;
using System.Linq;
using iread_story.DataAccess.Data;
using iread_story.DataAccess.Data.Entity;
using iread_story.DataAccess.Interface;

namespace iread_story.DataAccess.Service
     {
     class StoryService: IStory
     {
         private readonly AppDbContext _context;

         public StoryService(AppDbContext dbContext)
         {
             _context = dbContext;
         }

         public Story GetStory(int id)
         {
            return _context.Stories.Find(id);
         }

         public void UpdateStory(int id, Story story)
         {
             _context.Stories.Update(story);
             _context.SaveChanges();
         }

         public async void  AddStory(Story story)  
         {
             await _context.Stories.AddAsync(story);
             await _context.SaveChangesAsync();
         }

         public IEnumerable<Story>  GetStories()
         {
             return _context.Stories.AsEnumerable();
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

         public IEnumerable<Story> GetStoriesByIds(List<int> ids)
         {
             return _context.Stories.Where(story => ids.Contains(story.StoryId)).AsEnumerable();
         }
     }
     }