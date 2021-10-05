using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Globalization;

using iread_story.Web.Service;
using iread_story.DataAccess.Data.Entity;
using iread_story.Web.DTO.Language;
using iread_story.Web.Util;

namespace iread_story.Web.Controller
{
    [ApiController]
    [Route("api/[controller]/")]
    public class LanguageController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly LanguageService _languageService;
        public LanguageController(IMapper mapper, LanguageService languageService)
        {
            _mapper = mapper;
            _languageService = languageService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllLanguages()
        {
            List<Language> languages = await _languageService.GetAllLanguges();
            if (!languages.Any())
            {
                return NoContent();
            }
            return Ok(languages.ConvertAll<LanguageGetDto>(l => _mapper.Map<LanguageGetDto>(l)));
        }
        [HttpGet("active")]
        public async Task<IActionResult> GetActiveLanguages()
        {
            List<Language> languages = await _languageService.GetActiveLanguages();
            if (!languages.Any() || languages.Count() == 0)
            {
                return NotFound();
            }
            return Ok(languages.ConvertAll<LanguageGetDto>(l => _mapper.Map<LanguageGetDto>(l)));
        }

        [HttpPost("toggle-activate/{id:int}")]
        public async Task<IActionResult> ToggleActivate(int id)
        {
            if (!await _languageService.LanguageExists(id))
            {
                return NotFound(ErrorMessages.LANGUAGE_NOT_EXISTS);
            }
            Language updtedLanguage = await _languageService.ToggleActiveLanguage(id);
            return Ok(_mapper.Map<LanguageGetDto>(updtedLanguage));

        }


        [HttpPost("add")]
        public async Task<IActionResult> AddLanguage([FromBody] LanguageAddDto languageAddDto)
        {
            if (await _languageService.LanguageExists(_mapper.Map<Language>(languageAddDto)))
            {
                return BadRequest(ErrorMessages.LANGUAGE_EXISTS);
            }
            Language language = await _languageService.AddLanguage(_mapper.Map<Language>(languageAddDto));
            if (language == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<LanguageGetDto>(language));
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteLanguage(int id)
        {

            if (!await _languageService.LanguageExists(id))
            {
                return NotFound(ErrorMessages.LANGUAGE_NOT_EXISTS);
            }
            Language language = _languageService.DeleteLanguage(id);
            if (language == null)
            {
                return BadRequest(ErrorMessages.LANGUAGE_NOT_DELETED);
            }
            return Ok(_mapper.Map<LanguageGetDto>(language));
        }
    }
}