using System.Collections.Generic;
using System.Threading.Tasks;
using iread_story.DataAccess.Data;
using iread_story.DataAccess.Data.Entity;
using iread_story.DataAccess.Interface;

namespace iread_story.DataAccess.Repository
{
    public class PageRepository:IPageRepository
    {
        private readonly AppDbContext _context;

        public PageRepository(AppDbContext context)
        {
            _context = context;
        }
        
        public Task<Page> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Page>> GetByStory(int storyId)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Page page)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(int id, Page page, Page oldPage)
        {
            throw new System.NotImplementedException();
        }
    }
}