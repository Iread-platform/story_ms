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

        public async Task<Language> AddLanguage(Language language)
        {
            Language addedLanguage = (await _context.Languages.AddAsync(language)).Entity;
            await _context.SaveChangesAsync();
            return addedLanguage;
        }

        public async Task<List<Language>> GetAllLanguages()
        {
            return await _context.Languages.ToListAsync();
        }

        public async Task<Language> GetLanguage(int id)
        {
            return await _context.Languages.FindAsync(id);
        }

        public async Task<Language> GetLanguage(string code)
        {
            return await _context.Languages.Where(l => l.Code.Equals(code)).FirstAsync();
        }

        public async Task<bool> IdExists(int id)
        {
            return (await _context.Languages.FindAsync(id)) != null;
        }

        public async Task<bool> CodeExists(string code)
        {
            return (await _context.Languages.Where(l => l.Code.Equals(code.ToLower())).ToListAsync()).Count() > 0;
        }
        public Language Delete(int id)
        {
            Language deleted = _context.Languages.Remove(_context.Languages.Find(id)).Entity;

            _context.SaveChanges();
            return deleted;
        }
        public async Task<List<Language>> GetActiveLanguages()
        {
            return await _context.Languages.Where(lanuage => lanuage.Active).ToListAsync();
        }

        public async Task<Language> ToogleActivate(int id)
        {
            Language language = await _context.Languages.FindAsync(id);
            language.Active = !language.Active;
            Language updatedLangage = _context.Languages.Update(language).Entity;
            await _context.SaveChangesAsync();
            return updatedLangage;
        }

    }
}