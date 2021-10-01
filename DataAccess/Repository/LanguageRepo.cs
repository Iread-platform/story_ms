using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using iread_story.DataAccess.Data;
using iread_story.DataAccess.Data.Entity;
using iread_story.DataAccess.Interface;
using Microsoft.EntityFrameworkCore;

namespace iread_story.DataAccess.Repository
{
    public class LanguageRepo : ILanguageRepo
    {
        private readonly AppDbContext _context;

        public LanguageRepo(AppDbContext context)
        {
            _context = context;
        }

        public Task<Language> AddLanguage(Language language)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Language>> GetAllLanguages()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Language>> GetLanguage(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}