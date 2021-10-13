using System.Threading.Tasks;
using System.Collections.Generic;

using iread_story.DataAccess.Data.Entity;
namespace iread_story.DataAccess.Interface
{

    public interface ILanguageRepo
    {
        public Task<List<Language>> GetAllLanguages();
        public Task<List<Language>> GetActiveLanguages();
        public Task<Language> GetLanguage(int id);
        public Task<Language> GetLanguage(string code);
        public Task<Language> AddLanguage(Language language);
        public Task<bool> IdExists(int id);
        public Task<bool> CodeExists(string code);
        public Language Delete(int id);
        public Task<Language> ToogleActivate(int id);
    }
}