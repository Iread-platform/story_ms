using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Consul;
using iread_story.DataAccess.Data.Entity;
using iread_story.DataAccess.Interface;
using iread_story.Web.Dto.UserDto;
using iread_story.Web.DTO;
using iread_story.Web.DTO.Category;
using iread_story.Web.DTO.Page;
using iread_story.Web.DTO.Review;
using iread_story.Web.DTO.Story;
using iread_story.Web.DTO.Tag;
using iread_story.Web.Service;
using iread_story.Web.Util;
using iread_story.Web.Utils;
using Microsoft.AspNetCore.Authorization;
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
        private readonly string _categoriesMs = "tag_ms";
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
                viewStory.Category = await GetCategoryFromMs(story.StoryId);
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
            viewStory.Category = await GetCategoryFromMs(story.StoryId);
            return Ok(viewStory);
        }

        private Task<InnerCategoryDto> GetCategoryFromMs(int storyId)
        {
            return _consulHttpClient.GetAsync<InnerCategoryDto>("tag_ms", $"/api/category/get-by-story/{storyId}");
        }

        [HttpGet("get-by-title/{title}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByTitle(string title)
        {
            List<Story> stories = await _storyService.GetByTitle(title);
            if (stories == null || stories.Count == 0)
            {
                return NotFound();
            }

            List<SearchedStoryDto> SearchedStories = _mapper.Map<List<SearchedStoryDto>>(stories);
            await GetAttachmentsFromAttachmentMs(SearchedStories, stories);
            await GetCategoriesFromCategoryMs(SearchedStories, stories);
            await GetReviewsFromReviewMs(SearchedStories);
            return Ok(SearchedStories);
        }


        [HttpGet("get-by-level/{level}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByLevel([FromRoute] int level)
        {
            List<Story> stories = await _storyService.GetByLevel(level);
            if (stories == null || stories.Count == 0)
            {
                return NotFound();
            }

            List<SearchedStoryByLevelDto> SearchedStories = _mapper.Map<List<SearchedStoryByLevelDto>>(stories);
            await GetAttachmentsFromAttachmentMs(SearchedStories, stories);
            await GetCategoriesFromCategoryMs(SearchedStories, stories);
            return Ok(SearchedStories);
        }



        [HttpGet("get-by-my-appropriated-level")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetByMyAppropriatedLevel()
        {

            string myId = User.Claims.Where(c => c.Type == "sub")
                             .Select(c => c.Value).SingleOrDefault();

            UserDto user = await _consulHttpClient.GetAsync<UserDto>("identity_ms", $"/api/Identity/{myId}/get");

            List<Story> stories = await _storyService.GetByLevel(user.Level);

            if (stories == null || stories.Count == 0)
            {
                return NotFound();
            }

            List<SearchedStoryByLevelDto> SearchedStories = _mapper.Map<List<SearchedStoryByLevelDto>>(stories);
            await GetAttachmentsFromAttachmentMs(SearchedStories, stories);
            await GetCategoriesFromCategoryMs(SearchedStories, stories);
            return Ok(SearchedStories);
        }


        [HttpGet("get-by-my-appropriated-level-and-not-read-yet")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> GetByMyAppropriatedLevelAndNotReadYet()
        {

            string myId = User.Claims.Where(c => c.Type == "sub")
                             .Select(c => c.Value).SingleOrDefault();

            UserDto user = await _consulHttpClient.GetAsync<UserDto>("identity_ms", $"/api/Identity/{myId}/get");

            List<Story> stories = await _storyService.GetByLevel(user.Level);


            List<MiniStoryDto> readedStories = await _consulHttpClient.GetAsync<List<MiniStoryDto>>("interaction_ms", "api/Interaction/Reading/my-reading-stories");
            List<int> readedStoryIds = new List<int>();
            readedStories.ForEach(s => readedStoryIds.Add(s.StoryId));


            List<Story> notReadedStories = stories.FindAll(s => !readedStoryIds.Contains(s.StoryId));

            if (notReadedStories == null || notReadedStories.Count == 0)
            {
                return NotFound();
            }

            List<SearchedStoryByLevelDto> searchedStories = _mapper.Map<List<SearchedStoryByLevelDto>>(notReadedStories);
            await GetAttachmentsFromAttachmentMs(searchedStories, notReadedStories);
            await GetCategoriesFromCategoryMs(searchedStories, stories);
            return Ok(searchedStories);
        }






        [HttpGet("getStoryToListen/{id:int}", Name = "GetStoryToListen")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> getStoryToListen(int id)
        {
            Story story = await _storyService.GetStory(id);
            if (story == null)
            {
                return NotFound();
            }

            ListenStoryDto viewStory = new ListenStoryDto();
            viewStory.Audio = await GetAttachmentFromAttachmentMs(story.AudioId);
            viewStory.Pages = _mapper.Map<List<PageWithoutStoryDto>>(story.Pages);
            viewStory.PagesCount = viewStory.Pages.Count;
            viewStory.Category = await GetCategoryFromMs(story.StoryId);


            return Ok(viewStory);
        }


        [HttpPost("get-stories-to-read", Name = "GetStoriesToRead")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetStoriesToRead([FromForm] string ids)
        {
            List<int> idsAsInt = Array.ConvertAll(ids.Split(","), s => int.Parse(s)).OfType<int>().ToList();
            List<Story> stories = _storyService.GetStoriesByIds(idsAsInt);
            if (stories == null || !stories.Any())
            {
                return NotFound();
            }

            List<ReadStoryDto> viewStories = _mapper.Map<List<ReadStoryDto>>(stories);
            await GetAttachmentsFromAttachmentMs(viewStories, stories);
            await GetCategoriesFromCategoryMs(viewStories, stories);
            return Ok(viewStories);
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddStory([FromBody] CreateStoryTitleDto storyWithTitle)
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

            return CreatedAtRoute("GetStory", new { Id = storyToAdd.StoryId }, storyToAdd);
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

            Story story = await _storyService.GetStory(storyWithAudio.StoryId);
            if (story == null)
            {
                return NotFound();
            }

            //update old attachment if story has previous audio OR insert new attachment

            List<IFormFile> attachments = new List<IFormFile>();
            attachments.Add(storyWithAudio.StoryAudio);

            AttachmentsWithStoryId currentAttachment;

            //update old attachment if story has previous audio
            if (story.AudioId != 0)
            {
                var parameters = new Dictionary<string, string>() { { "Id", story.AudioId.ToString() } };
                try
                {
                    await _consulHttpClient.PutFormAsync<AttachmentsWithStoryId>(_attachmentsMs, $"api/Attachment/update",
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
                var parameters = new Dictionary<string, string>() { { "StoryId", story.StoryId.ToString() } };
                try
                {
                    currentAttachment = _consulHttpClient.PostFormAsync<AttachmentsWithStoryId>(_attachmentsMs, "api/Attachment/add",
                        parameters, attachments?.ToList()).Result;
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("Audio", e.Message);
                    return BadRequest(ErrorMessages.ModelStateParser(ModelState));
                }

                //Insert audio id to story
                story.AudioId = currentAttachment.Id;
                if (!_storyService.UpdateStory(story.StoryId, story))
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

            Story story = await _storyService.GetStory(storyWithCover.StoryId);
            if (story == null)
            {
                return NotFound();
            }

            //update old attachment if story has previous cover OR insert new attachment

            List<IFormFile> attachments = new List<IFormFile>();
            attachments.Add(storyWithCover.StoryCover);

            AttachmentsWithStoryId currentAttachment;

            //update old attachment if story has previous cover
            if (story.CoverId != 0)
            {
                var parameters = new Dictionary<string, string>() { { "Id", story.CoverId.ToString() } };
                try
                {
                    await _consulHttpClient.PutFormAsync<AttachmentsWithStoryId>(_attachmentsMs, $"api/Attachment/update",
                        parameters, attachments?.ToList());
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("Cover", e.Message);
                    return BadRequest(ErrorMessages.ModelStateParser(ModelState));
                }
            }
            else
            {
                //Insert attachment before update story
                var parameters = new Dictionary<string, string>() { { "StoryId", story.StoryId.ToString() } };
                try
                {
                    currentAttachment = await _consulHttpClient.PostFormAsync<AttachmentsWithStoryId>(_attachmentsMs, "api/Attachment/add",
                        parameters, attachments?.ToList());
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("Cover", e.Message);
                    return BadRequest(ErrorMessages.ModelStateParser(ModelState));
                }

                //Insert cover id to story
                story.CoverId = currentAttachment.Id;
                if (!_storyService.UpdateStory(story.StoryId, story))
                {
                    return BadRequest();
                }
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

        //TODO Add api for post and update story tags

        [HttpPut("addTags")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddStoryTags([FromBody] CreateStoryTagsDto storyWithTags)
        {
            if (storyWithTags == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorMessages.ModelStateParser(ModelState));
            }

            Story story = await _storyService.GetStory(storyWithTags.StoryId);
            if (story == null)
            {
                return NotFound();
            }

            if (storyWithTags.KeyWords != null)
            {
                TagsWithStoryId tagsWithStoryId = new TagsWithStoryId()
                {
                    storyId = storyWithTags.StoryId,
                    tagsDtos = storyWithTags.KeyWords.ToList()
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

            oldStory.Description = story.Description;
            oldStory.Title = story.Title;
            oldStory.Writer = story.Writer;
            oldStory.ReleaseDate = story.ReleaseDate;
            oldStory.StoryLevel = story.StoryLevel;

            if (!_storyService.UpdateStory(story.StoryId, oldStory))
            {
                return BadRequest();
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

        private async Task GetReviewsFromReviewMs<T>(List<T> searchedStories) where T : GenericStoryDto
        {
            List<StoryReview> res = null;
            Dictionary<string, string> formData = new Dictionary<string, string>();
            string storyIds = "";
            searchedStories.ForEach(s =>
            {
                storyIds += s.StoryId + ",";
            });
            storyIds = storyIds.Remove(storyIds.Length - 1);

            formData.Add("ids", storyIds);
            res = await _consulHttpClient.PostFormAsync<List<StoryReview>>(_reviewMs, $"/api/Review/get-by-story_ids", formData, res);

            for (int index = 0; index < searchedStories.Count; index++)
            {
                searchedStories.ElementAt(index).Rating = res.ElementAt(index);
            }
        }

        private async Task GetCategoriesFromCategoryMs<T>(List<T> searchedStories, List<Story> stories) where T : GenericStoryDto
        {
            List<InnerCategoryDto> res = null;
            Dictionary<string, string> formData = new Dictionary<string, string>();
            string storyIds = "";
            stories.ForEach(s =>
            {
                storyIds += s.StoryId + ",";
            });
            storyIds = storyIds.Remove(storyIds.Length - 1);

            formData.Add("storiesIds", storyIds);
            res = await _consulHttpClient.PostFormAsync<List<InnerCategoryDto>>(_categoriesMs, $"/Api/category/get-by-stories", formData, res);

            for (int index = 0; index < searchedStories.Count; index++)
            {
                searchedStories.ElementAt(index).Category = res.ElementAt(index);
            }
        }


        private async Task GetAttachmentsFromAttachmentMs<T>(List<T> storiesDto, List<Story> stories) where T : GenericStoryDto
        {
            List<AttachmentDTO> res = null;
            Dictionary<string, string> formData = new Dictionary<string, string>();
            string coverIds = "";
            stories.ForEach(s =>
            {
                coverIds += s.CoverId + ",";
            });
            coverIds = coverIds.Remove(coverIds.Length - 1);

            formData.Add("ids", coverIds);
            res = await _consulHttpClient.PostFormAsync<List<AttachmentDTO>>(_attachmentsMs, $"/api/attachment/get-by-ids", formData, res);

            for (int index = 0; index < storiesDto.Count; index++)
            {
                storiesDto.ElementAt(index).StoryCover = res.ElementAt(index);
            }
        }
    }
}