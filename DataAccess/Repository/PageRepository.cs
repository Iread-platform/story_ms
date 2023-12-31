﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using iread_story.DataAccess.Data;
using iread_story.DataAccess.Data.Entity;
using iread_story.DataAccess.Interface;
using Microsoft.EntityFrameworkCore;

namespace iread_story.DataAccess.Repository
{
    public class PageRepository : IPageRepository
    {
        private readonly AppDbContext _context;

        public PageRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Page> GetById(int id)
        {
            return await _context.Pages.Include(p => p.Story).SingleOrDefaultAsync(p => p.PageId == id);
        }

        public Task<List<Page>> GetByStory(int storyId)
        {
            return _context.Pages.Where(r => r.StoryId == storyId).ToListAsync();
        }

        public void Insert(Page page)
        {
            _context.Pages.Add(page);
            _context.SaveChangesAsync();
        }

        public void Delete(Page page)
        {
            _context.Pages.Remove(page);
            _context.SaveChanges();
        }

        public void Update(int id, Page page, Page oldPage)
        {
            _context.Entry(oldPage).State = EntityState.Modified;
            _context.Pages.Attach(oldPage);
            oldPage.Content = page.Content;
            oldPage.Words = page.Words;
            _context.Update(oldPage);
            _context.SaveChanges();
        }

        public bool IsExists(int id)
        {
            return _context.Pages.Any(p => p.PageId == id);
        }

        public async Task<int> GetPagesCount(int storyId)
        {
            return await _context.Pages.Where(p => p.StoryId == storyId).CountAsync();
        }

        public void IncreasePagesNumbersFrom(int storyId, int index)
        {
            _context.Database.ExecuteSqlRaw($"UPDATE Pages  SET  No = No + 1 WHERE StoryId = {storyId} AND No >= {index}");
        }

        public void DecreasePagesNumbersFrom(int storyId, int index)
        {
            _context.Database.ExecuteSqlRaw($"UPDATE Pages  SET  No = No - 1 WHERE StoryId = {storyId} AND No >= {index}");
        }

        public void Update(Page page)
        {
            _context.Update(page);
            _context.SaveChanges();
        }
    }
}