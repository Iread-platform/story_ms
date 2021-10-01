using System.Threading.Tasks;
using System.Collections.Generic;

using iread_story.DataAccess.Data.Entity;
namespace iread_story.DataAccess.Interface
{

    public interface ILanguageRepo
    {
        public Task<List<Language>> GetAllLanguages();
        public Task<List<Language>> GetLanguage(int id);
        public Task<Language> AddLanguage(Language language);
    }
}