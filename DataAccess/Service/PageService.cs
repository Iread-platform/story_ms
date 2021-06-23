using System.Collections.Generic;
using System.Threading.Tasks;
using iread_story.DataAccess.Interface;
using iread_story.DataAccess.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace iread_story.DataAccess.Service
{
    public class PageService
    {
        private readonly IPublicRepository _repository;

        public PageService(IPublicRepository repository)
        {
            _repository = repository;
        }
        
        public bool InsertPage(Page page)
        {
            try
            {
                _repository.GetPageRepository.Insert(page);
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }
        
        public async Task<Page> GetPageById(int id)
        {
            return await _repository.GetPageRepository.GetById(id);
        }
        
        public bool UpdatePage(Page page, Page oldPage)
        {
            try
            {
                _repository.GetPageRepository.Update(page.PageId, page, oldPage);
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }
        
        public bool Delete(int id)
        {
            try
            {
                _repository.GetPageRepository.Delete(id);
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            
        }
        
        public async Task<List<Page>> GetPagesByStory(int storyId)
        {
            return await _repository.GetPageRepository.GetByStory(storyId);
        }
    }
}