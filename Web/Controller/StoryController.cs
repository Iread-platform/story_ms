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
    [Route("api/[controller]")]
    public class StoriesController : ControllerBase
    {

        private readonly ILogger<StoriesController> _logger;

        public StoriesController(ILogger<StoriesController> logger)
        {
            _logger = logger;
        }

        [HttpGet("test")]
        public IEnumerable<Story> GetStories()
        {
            List<Story> stories = new List<Story>();
            stories.Add(new Story { StoryId = 1 ,
            Title = "Things Fall Apart",
            ReleaseDate = DateTime.Now.AddYears(-10)
            }); 
            stories.Add(new Story { StoryId = 2 ,
            Title = "Nineteen Eighty-Four",
            ReleaseDate = DateTime.Now.AddYears(-5)
            });
            stories.Add(new Story { StoryId = 3 ,
            Title = "Frankenstein",
            ReleaseDate = DateTime.Now.AddYears(-15)
            });
            return stories;
        }
    }
}
