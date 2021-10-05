using System.Collections.Generic;
using System.Threading.Tasks;
using iread_story.DataAccess.Interface;
using iread_story.DataAccess.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;

namespace iread_story.Web.Service
{
    public class LanguageService
    {
        private readonly IPublicRepository _repository;

        public LanguageService(IPublicRepository repository)
        {
            _repository = repository;
        }
        public async Task<Language> AddLanguage(Language language)
        {
            return await _repository.GetLanguageRepo.AddLanguage(language);
        }

        public async Task<List<Language>> GetAllLanguges()
        {
            return await _repository.GetLanguageRepo.GetAllLanguages();
        }

        public async Task<Language> GetLanuageById(int id)
        {
            return await _repository.GetLanguageRepo.GetLanguage(id);
        }

        public async Task<Language> GetLanuageByCode(string code)
        {
            return await _repository.GetLanguageRepo.GetLanguage(code);
        }


        public async Task<bool> LanguageExists(Language language)
        {
            return await _repository.GetLanguageRepo.Exists(language.LanguageId) || await _repository.GetLanguageRepo.Exists(language.Code);
        }

        public async Task<bool> LanguageExists(int id)
        {
            return await _repository.GetLanguageRepo.Exists(id);
        }

        public async Task<bool> LanguageExists(string code)
        {
            return await _repository.GetLanguageRepo.Exists(code);
        }


        public Language DeleteLanguage(int id)
        {
            return _repository.GetLanguageRepo.Delete(id);
        }

        public async Task<List<Language>> GetActiveLanguages()
        {
            return await _repository.GetLanguageRepo.GetActiveLanguages();
        }

        public async Task<Language> ToggleActiveLanguage(int id)
        {
            return await _repository.GetLanguageRepo.ToogleActivate(id);
        }
    }
}