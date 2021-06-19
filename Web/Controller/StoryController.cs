using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Consul;
using iread_story.DataAccess.Data.Entity;
using iread_story.DataAccess.Data.Types;
using iread_story.DataAccess.Interface;
using iread_story.Web.DTO;
using iread_story.Web.DTO.Story;
using iread_story.Web.DTO.Tag;
using iread_story.Web.Service;
using iread_story.Web.Utils;
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
        private readonly IConsulHttpClientService _consulHttpClient;
        private readonly string _attachmentsMs = "attachment_ms";
        public StoryController(ILogger<StoryController> logger, IPublicRepository repository, IMapper mapper, IConsulHttpClientService consulHttpClient)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _consulHttpClient = consulHttpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetStories()
        {
            List<ViewStoryDto> stories = new List<ViewStoryDto>(); 
                foreach (Story story in _repository.getStoryService.GetStories())
                {
                    ViewStoryDto viewStory = _mapper.Map<ViewStoryDto>(story);
                    viewStory.Attachments =await GetAttachmentFromAttachmentMs(story.StoryId);
                    viewStory.KeyWords =await GetTagsFromTagMs(story.StoryId);
                    stories.Add(viewStory);
                }

            return Ok(stories);
        }
        
        [HttpGet("{id:int}", Name = "GetStory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStory(int id)
        {
            Story story = _repository.getStoryService.GetStory(id);
            ViewStoryDto viewStory = _mapper.Map<ViewStoryDto>(story);
            viewStory.Attachments =await GetAttachmentFromAttachmentMs(id);
            viewStory.KeyWords =await GetTagsFromTagMs(id);
            return viewStory == null ? NotFound() : Ok(viewStory);
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddStory([FromForm] CreateStoryDto story)
        {
            if (story == null)
            {
                return BadRequest(ModelState);
            }

            Story storyToAdd = _mapper.Map<Story>(story);
            _repository.getStoryService.AddStory(storyToAdd);

            if (story.KeyWords != null)
            {
                TagsWithStoryId tagsWithStoryId = new TagsWithStoryId()
                {
                    storyId = storyToAdd.StoryId,
                    tagsDtos = story.KeyWords.ToList()
                };
                try
                {
                    await _consulHttpClient.PostBodyAsync<TagWithIdDto[]>("tag_ms", "/api/tags", tagsWithStoryId);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }

            if (story.Attachments != null)
            {
                var parameters = new Dictionary<string, string>() { {"StoryId",storyToAdd.StoryId.ToString()} };

                try
                {
                    await _consulHttpClient.PostFormAsync<AttachmentsWithStoryId>(_attachmentsMs, "api/Attachment",
                        parameters, story.Attachments?.ToList());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            ViewStoryDto addedStory = _mapper.Map<ViewStoryDto>(storyToAdd);

            addedStory.KeyWords = await GetTagsFromTagMs(storyToAdd.StoryId);
            addedStory.Attachments = await GetAttachmentFromAttachmentMs(storyToAdd.StoryId);
            
            return CreatedAtRoute("GetStory",new { Id = storyToAdd.StoryId }, addedStory);
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
        public async Task<IActionResult> UpdateStory(int id, [FromForm] UpdateStoryDto story)
        {
            if(story == null || !ModelState.IsValid){ return BadRequest(ModelState); }

            story.StoryId = id; 
            if (!_repository.getStoryService.Exists(id))
            {
                return NotFound();
            }

            var storyToUpdate = _mapper.Map<Story>(story);
            _repository.getStoryService.UpdateStory(id, storyToUpdate);

            if (story.KeyWords != null)
            {
                await _consulHttpClient.PutBodyAsync<TagWithIdDto[]>("tag_ms", "/api/tags", 
                    new TagsWithStoryId{
                        tagsDtos = story.KeyWords.ToList()
                        ,storyId = id
                    });
            }
            
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

        private async Task<List<AttachmentDTO>> GetAttachmentFromAttachmentMs(int storyId)
        {
            try
            {
                return await _consulHttpClient.GetAsync<List<AttachmentDTO>>(_attachmentsMs, $"api/attachment/GetAttachmentsByStoryId/{storyId}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        private async Task<List<TagWithIdDto>> GetTagsFromTagMs(int storyId)
        {
            try
            {
               return await _consulHttpClient.GetAsync<List<TagWithIdDto>>("tag_ms", $"api/tags/GetTagsByStoryId/{storyId}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }
        
    }
}
