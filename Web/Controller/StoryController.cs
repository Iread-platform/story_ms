using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using iread_story.DataAccess.Data.Entity;
using iread_story.DataAccess.Interface;
using iread_story.Web.DTO.Story;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace iread_story.Web.Controller
{
    [ApiController]
    [Route("api/[controller]/")]
    public class StoriesController : ControllerBase
    {

        private readonly ILogger<StoriesController> _logger;
        private readonly IPublicRepository _repository;
        private readonly IMapper _mapper;
        public StoriesController(ILogger<StoriesController> logger, IPublicRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetStories()
        {
            List<StoryDto> stories = new List<StoryDto>(); 
                foreach (Story storey in _repository.getStoryService.GetStories())
                {
                    stories.Add(_mapper.Map<StoryDto>(storey));
                }

            return Ok(stories);
        }
        
        [HttpGet("{id:int}", Name = "GetStory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetStory(int id)
        {
            Story story = _repository.getStoryService.GetStory(id);
            return story == null ? NotFound() : Ok(story);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddStory([FromBody] Story story)
        {
            if (story == null)
            {
                return BadRequest();
            }
            _repository.getStoryService.AddStory(story);
            return CreatedAtRoute("GetStory",new { Id = story.StoryId }, story);
        }
        
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteStory(int id)
        {
            if (!_repository.getStoryService.Exists(id))
            {
                return NotFound();
            }
            _repository.getStoryService.DeleteStory(id);
            return _repository.getStoryService.Exists(id) ?   StatusCode(500) :   Ok();
        }
    }
}
