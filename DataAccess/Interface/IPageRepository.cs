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

        public void Delete(Page page);

        public void Update(int id, Page page, Page oldPage);

        bool IsExists(int id);

        public Task<int> GetPagesCount(int storyId);
        public void IncreasePagesNumbersFrom(int storyId, int Index);
        public void DecreasePagesNumbersFrom(int storyId, int Index);
    }
}