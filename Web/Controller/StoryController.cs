using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using iread_story.DataAccess.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace iread_story.Web.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class StoryController : ControllerBase
    {

        private readonly ILogger<StoryController> _logger;

        public StoryController(ILogger<StoryController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Story> GetStories()
        {
            List<Story> stories = new List<Story>();
            stories.Add(new Story { StoryId = 1 ,
            title = "Things Fall Apart",
            ReleaseDate = DateTime.Now.AddYears(-10)
            }); 
            stories.Add(new Story { StoryId = 2 ,
            title = "Nineteen Eighty-Four",
            ReleaseDate = DateTime.Now.AddYears(-5)
            });
            stories.Add(new Story { StoryId = 3 ,
            title = "Frankenstein",
            ReleaseDate = DateTime.Now.AddYears(-15)
            });
            return stories;
        }
    }
}
