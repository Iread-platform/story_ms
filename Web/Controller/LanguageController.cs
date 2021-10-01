using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace iread_story.Web.Controller
{
    [ApiController]
    [Route("api/[controller]/")]
    public class LanguageController : ControllerBase
    {
        private readonly ILogger<StoryController> _logger;
        private readonly IMapper _mapper;
        public LanguageController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("all")]
        public IActionResult GetAllLanguages()
        {
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            return Ok(cultures);
        }
    }
}