using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Consul;
using iread_story.DataAccess.Data.Entity;
using iread_story.DataAccess.Data.Types;
using iread_story.DataAccess.Interface;
using iread_story.Web.DTO.Story;
using iread_story.Web.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace iread_story.Web.Controller
{
    [ApiController]
    [Route("api/[controller]/")]
    public class StoryController : ControllerBase
    {

        private readonly ILogger<StoryController> _logger;
        private readonly IPublicRepository _repository;
        private readonly IMapper _mapper;
        private readonly IConsulHttpClientService _consulClient;
        private const string _attachmentsMs = "attachment_ms"; 
        public StoryController(ILogger<StoryController> logger, IPublicRepository repository, IMapper mapper, IConsulHttpClientService consulClient)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _consulClient = consulClient;
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
        public async Task<IActionResult> AddStory([FromForm] StoryDto story)
        {
            if (story == null)
            {
                return BadRequest(ModelState);
            }
            var storyToCreate = _mapper.Map<Story>(story);
            _repository.getStoryService.AddStory(storyToCreate);
            var parameters = new Dictionary<string, string>() { {"StoryId",storyToCreate.StoryId.ToString()} };
            await _consulClient.PostAsync<AttachmentsWithStoryId>(_attachmentsMs, "api/Attachment",parameters, story.Attachments?.ToList());
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
        public IActionResult UpdateStory(int id, [FromForm] List<IFormFile> attachments, [FromBody] StoryUpdateDto story)
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
