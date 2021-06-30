using System.Collections.Generic;
using System.Threading.Tasks;
using iread_story.DataAccess.Data.Entity;

namespace iread_story.DataAccess.Interface
{
    public interface IPageRepository
    {
        public Task<Page> GetById(int id);

        public Task<List<Page>> GetByStory(int storyId);

        public void Insert(Page page);
        
        public void Delete(int id);
        
        public void Update(int id, Page page, Page oldPage);
        
        bool IsExists(int id);
    }
}