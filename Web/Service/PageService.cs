using System.Collections.Generic;
using System.Threading.Tasks;
using iread_story.DataAccess.Interface;
using iread_story.DataAccess.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace iread_story.Web.Service
{
    public class PageService
    {
        private readonly IPublicRepository _repository;

        public PageService(IPublicRepository repository)
        {
            _repository = repository;
        }

        public void InsertPage(Page page)
        {
            page.No = 1 + _repository.GetPageRepository.GetPagesCount(page.StoryId).Result;
            _repository.GetPageRepository.Insert(page);
        }

        public async Task<Page> GetPageById(int id)
        {
            return await _repository.GetPageRepository.GetById(id);
        }

        public void IncreasePagesNumbersFrom(int storyId, int index)
        {
            _repository.GetPageRepository.IncreasePagesNumbersFrom(storyId, index);
        }
        public void DecreasePagesNumbersFrom(int storyId, int index)
        {
            _repository.GetPageRepository.DecreasePagesNumbersFrom(storyId, index);
        }

        public void UpdatePage(Page page, Page oldPage)
        {
            _repository.GetPageRepository.Update(page.PageId, page, oldPage);

        }
        public void UpdatePage(Page page)
        {
            _repository.GetPageRepository.Update(page);
        }

        public void Delete(Page page)
        {
            _repository.GetPageRepository.DecreasePagesNumbersFrom(page.StoryId, page.No + 1);
            _repository.GetPageRepository.Delete(page);
        }

        public async Task<List<Page>> GetPagesByStory(int storyId)
        {
            return await _repository.GetPageRepository.GetByStory(storyId);
        }

        public bool IsStoryExists(int storyId)
        {
            return _repository.GetStoryService.Exists(storyId);
        }

        public bool IsExists(int id)
        {
            return _repository.GetPageRepository.IsExists(id);
        }

        public async Task<int> GetPagesCount(int storyId)
        {
            return await _repository.GetPageRepository.GetPagesCount(storyId);
        }

        public void InsertPageIn(Page page, int index)
        {
            page.No = index;
            _repository.GetPageRepository.IncreasePagesNumbersFrom(page.StoryId, index);
            _repository.GetPageRepository.Insert(page);
        }
    }
}