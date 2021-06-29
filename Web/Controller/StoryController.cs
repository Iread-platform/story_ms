using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Consul;
using iread_story.DataAccess.Data.Entity;
using iread_story.DataAccess.Interface;
using iread_story.Web.DTO;
using iread_story.Web.DTO.Review;
using iread_story.Web.DTO.Story;
using iread_story.Web.DTO.Tag;
using iread_story.Web.Service;
using iread_story.Web.Util;
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
        private readonly IMapper _mapper;
        private readonly IConsulHttpClientService _consulHttpClient;
        private readonly string _attachmentsMs = "attachment_ms";
        private readonly string _reviewMs = "review_ms";
        private readonly StoryService _storyService;

        public StoryController(ILogger<StoryController> logger, IMapper mapper,
            IConsulHttpClientService consulHttpClient, StoryService storyService)
        {
            _logger = logger;

            _mapper = mapper;
            _consulHttpClient = consulHttpClient;
            _storyService = storyService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetStories()
        {
            List<ViewStoryDto> viewStories = new List<ViewStoryDto>();
            List<Story> stories = _storyService.GetStories();
            if (!stories.Any())
            {
                return NotFound();
            }

            foreach (Story story in stories)
            {
                ViewStoryDto viewStory = _mapper.Map<ViewStoryDto>(story);
                viewStory.StoryAudio = await GetAttachmentFromAttachmentMs(story.AudioId);
                viewStory.StoryCover = await GetAttachmentFromAttachmentMs(story.CoverId);
                viewStory.Rating = await GetReviewFromReviewMs(story.StoryId);
                viewStory.KeyWords = await GetTagsFromTagMs(story.StoryId);
                viewStories.Add(viewStory);
            }

            return Ok(viewStories);
        }

        [HttpGet("get/{id:int}", Name = "GetStory")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStory(int id)
        {
            Story story = await _storyService.GetStory(id);
            if (story == null)
            {
                return NotFound();
            }

            ViewStoryDto viewStory = _mapper.Map<ViewStoryDto>(story);
            viewStory.StoryAudio = await GetAttachmentFromAttachmentMs(story.AudioId);
            viewStory.StoryCover = await GetAttachmentFromAttachmentMs(story.CoverId);
            viewStory.Rating = await GetReviewFromReviewMs(story.StoryId);
            viewStory.KeyWords = await GetTagsFromTagMs(story.StoryId);
            return Ok(viewStory);
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddStory([FromForm] CreateStoryTitleDto storyWithTitle)
        {
            if (storyWithTitle == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorMessages.ModelStateParser(ModelState));
            }

            Story storyToAdd = _mapper.Map<Story>(storyWithTitle);
            
            //TODO Add user id that come from token to story model before add it
            
            if (!_storyService.AddStory(storyToAdd))
            {
                return BadRequest();
            }

            return CreatedAtRoute("GetStory", new {Id = storyToAdd.StoryId}, storyToAdd);
        }

        [HttpPut("addAudio")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddStoryAudio([FromForm] CreateStoryAudioDto storyWithAudio)
        {
            if (storyWithAudio == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorMessages.ModelStateParser(ModelState));
            }

            //TODO Add Check if the user who updated the story is its owner
            
            Story story = await _storyService.GetStory(storyWithAudio.StoryId);
            if (story == null)
            {
                return NotFound();
            }
            
            //update old attachment if story has previous audio OR insert new attachment
            var parameters = new Dictionary<string, string>() { {"StoryId",story.StoryId.ToString()} };

            List<IFormFile> attachments = new List<IFormFile>();
            attachments.Add(storyWithAudio.StoryAudio);
            
            AttachmentsWithStoryId currentAttachment;
            
            //update old attachment if story has previous audio
            if (story.AudioId != 0)
            {
                try
                {
                    await _consulHttpClient.PutFormAsync<AttachmentsWithStoryId>(_attachmentsMs, $"api/Attachment/update/{story.AudioId}",
                        parameters, attachments?.ToList());
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("Audio", e.Message);
                    return BadRequest(ErrorMessages.ModelStateParser(ModelState));
                }
            }
            else
            {
                //Insert attachment before update story
                try
                {
                    currentAttachment = await _consulHttpClient.PostFormAsync<AttachmentsWithStoryId>(_attachmentsMs, "api/Attachment/add",
                        parameters, attachments?.ToList());
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("Audio", e.Message);
                    return BadRequest(ErrorMessages.ModelStateParser(ModelState));
                }
                
                //Insert audio id to story
                story.AudioId = currentAttachment.Id;
                if (!_storyService.UpdateStory(story.StoryId, story, story))
                {
                    return BadRequest();
                }
            }
            
            return NoContent();
        }

        [HttpPut("addCover")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddStoryCover([FromForm] CreateStoryCoverDto storyWithCover)
        {
            if (storyWithCover == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorMessages.ModelStateParser(ModelState));
            }
            
            //TODO Add Check if the user who updated the story is its owner

            Story story = await _storyService.GetStory(storyWithCover.StoryId);
            if (story == null)
            {
                return NotFound();
            }
            
            //Insert attachment before update story
            var parameters = new Dictionary<string, string>() { {"StoryId",story.StoryId.ToString()} };

            List<IFormFile> attachments = new List<IFormFile>();
            attachments.Add(storyWithCover.StoryCover);

            AttachmentsWithStoryId attachmentAfterPost = new AttachmentsWithStoryId();
            try
            {
                attachmentAfterPost = await _consulHttpClient.PostFormAsync<AttachmentsWithStoryId>(_attachmentsMs, "api/Attachment/add",
                    parameters, attachments?.ToList());
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Cover", e.Message);
                return BadRequest(ErrorMessages.ModelStateParser(ModelState));
            }
            
            //Insert cover id to story
            story.CoverId = attachmentAfterPost.Id;
            if (!_storyService.UpdateStory(story.StoryId, story,story))
            {
                return BadRequest();
            }

            return NoContent();
        }
        
        
        [HttpDelete("delete/{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteStory(int id)
        {
            if (!_storyService.Exists(id))
            {
                return NotFound();
            }
            
            //TODO Add Check if the user who deleted the story is its owner

            if (!_storyService.DeleteStory(id))
            {
                return BadRequest();
            }
            return NoContent();
        }
        
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateStory([FromForm] UpdateStoryDto story)
        {
            if (story == null || !ModelState.IsValid)
            {
                return BadRequest(ErrorMessages.ModelStateParser(ModelState));
            }

            Story oldStory = await _storyService.GetStory(story.StoryId);
            if (oldStory == null)
            {
                return NotFound();
            }
        
            Story storyEntity = _mapper.Map<Story>(story);

            if (story.KeyWords != null)
            {
                TagsWithStoryId tagsWithStoryId = new TagsWithStoryId()
                {
                    storyId = storyEntity.StoryId,
                    tagsDtos = story.KeyWords.ToList()
                };
                try
                {
                    await _consulHttpClient.PostBodyAsync<TagWithIdDto[]>("tag_ms", "/api/tags/add", tagsWithStoryId);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("Tag", e.Message);
                    return BadRequest(ErrorMessages.ModelStateParser(ModelState));
                }
            }

            if (!_storyService.UpdateStory(storyEntity.StoryId, storyEntity, oldStory))
            {
                return BadRequest();
            }
        
            if (story.KeyWords != null)
            {
                await _consulHttpClient.PutBodyAsync<TagWithIdDto[]>("tag_ms", "/api/tags/update",
                    new TagsWithStoryId
                    {
                        tagsDtos = story.KeyWords.ToList(), storyId = story.StoryId
                    });
            }
        
            return NoContent();
        }
        
        [HttpGet("GetStoriesByTagTitle/{title}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetStoriesByTagTitle(String title)
        {
            List<int> ids =
                await _consulHttpClient.GetAsync<List<int>>("tag_ms", $"/api/tags/GetStoriesIdsByTagTitle/{title}");
        
            var result = _storyService.GetStoriesByIds(ids);
        
            return Ok(result);
        }
        
        private async Task<AttachmentDTO> GetAttachmentFromAttachmentMs(int attachmentId)
        {
            try
            {
                return await _consulHttpClient.GetAsync<AttachmentDTO>(_attachmentsMs,
                    $"api/attachment/get/{attachmentId}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }

        private async Task<StoryReview> GetReviewFromReviewMs(int storyId)
        {
            try
            {
                return await _consulHttpClient.GetAsync<StoryReview>(_reviewMs, $"api/review/StoryReview/{storyId}");
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
                return await _consulHttpClient.GetAsync<List<TagWithIdDto>>("tag_ms",
                    $"api/tags/GetTagsByStoryId/{storyId}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }
    }
}