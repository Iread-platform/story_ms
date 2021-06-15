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
    public class StoryController : ControllerBase
    {

        private readonly ILogger<StoryController> _logger;
        private readonly IPublicRepository _repository;
        private readonly IMapper _mapper;
        public StoryController(ILogger<StoryController> logger, IPublicRepository repository, IMapper mapper)
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
        public IActionResult AddStory([FromBody] StoryDto story)
        {
            if (story == null)
            {
                return BadRequest(ModelState);
            }
            var storyToCreate = _mapper.Map<Story>(story);
            _repository.getStoryService.AddStory(storyToCreate);
            return CreatedAtRoute("GetStory",new { Id = storyToCreate.StoryId }, storyToCreate);
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
        
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateStory(int id, [FromBody] StoryUpdateDto story)
        {
            if(story == null || !ModelState.IsValid){ return BadRequest(ModelState); }

            story.StoryId = id; 
            if (!_repository.getStoryService.Exists(id))
            {
                return NotFound();
            }

            var storyToUpdate = _mapper.Map<Story>(story);
            _repository.getStoryService.UpdateStory(id, storyToUpdate);
            return NoContent();
        }
    }
}
