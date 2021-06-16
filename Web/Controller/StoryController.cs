using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using iread_story.DataAccess.Data.Entity;
using iread_story.DataAccess.Interface;
using iread_story.Web.DTO.Story;
using iread_story.Web.DTO.Tag;
using iread_story.Web.Service;
using iread_story.Web.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly IConsulHttpClient _consulHttpClient;
        public StoryController(ILogger<StoryController> logger, IPublicRepository repository, IMapper mapper, IConsulHttpClient consulHttpClient)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _consulHttpClient = consulHttpClient;
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
        public async Task<IActionResult> AddStory([FromBody] CreateStoryDto story)
        {
    
            if (story == null)
            {
                return BadRequest(ModelState);
            }

            Story storyToAdd = _mapper.Map<Story>(story);
            _repository.getStoryService.AddStory(storyToAdd);
            
            
            await _consulHttpClient.PostAsync<TagWithIdDto[]>("tag_ms", "/api/tags", 
                new TagsWithStoryId{
                    tagsDtos = story.KeyWords.ToList()
                    ,storyId = storyToAdd.StoryId
                } );
            
            return CreatedAtRoute("GetStory",new { Id = storyToAdd.StoryId }, _mapper.Map<StoryDto>(storyToAdd));
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
        public async Task<IActionResult> UpdateStory(int id, [FromBody] UpdateStoryDto story)
        {
            if(story == null || !ModelState.IsValid){ return BadRequest(ModelState); }

            story.StoryId = id; 
            if (!_repository.getStoryService.Exists(id))
            {
                return NotFound();
            }

            var storyToUpdate = _mapper.Map<Story>(story);
            _repository.getStoryService.UpdateStory(id, storyToUpdate);
            
            await _consulHttpClient.PutAsync<TagWithIdDto[]>("tag_ms", "/api/tags", 
                new TagsWithStoryId{
                    tagsDtos = story.KeyWords.ToList()
                    ,storyId = id
                } );
            
            return NoContent();
        }
        
        [HttpGet()]
        [Route("GetStoriesByTagTitle/{title}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetStoriesByTagTitle(String title)
        {
            List<int> ids = await _consulHttpClient.GetAsync<List<int>>("tag_ms", $"/api/tags/GetStoriesIdsByTagTitle/{title}");

            var result = _repository.getStoryService.GetStoriesByIds(ids);

            return Ok(result);
        }
        
    }
}
