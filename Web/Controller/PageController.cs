using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using iread_story.DataAccess.Data.Entity;
using iread_story.Web.Service;
using iread_story.Web.DTO.Page;
using iread_story.Web.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using iread_story.Web.DTO;

namespace iread_story.Web.Controller
{
    [Route("/api/Story/[controller]")]
    public class PageController : ControllerBase
    {
        private readonly PageService _pageService;
        private readonly IMapper _mapper;
        private static string _attachmentsMs = "attachment_ms";
        private readonly IConsulHttpClientService _consulHttpClient;


        public PageController(PageService pageService, IMapper mapper, IConsulHttpClientService consulHttpClient)
        {
            _pageService = pageService;
            _mapper = mapper;
            _consulHttpClient = consulHttpClient;
        }

        // GET: api/page/get/1
        [HttpGet("get/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPage([FromRoute] int id)
        {
            Page page = await _pageService.GetPageById(id);

            if (page == null)
            {
                return NotFound();
            }
            PageDto res = _mapper.Map<PageDto>(page);
            res.Story.StoryAudio = await _consulHttpClient.GetAsync<AttachmentDTO>(_attachmentsMs, $"/api/Attachment/get/{page.Story.AudioId}");
            res.Story.StoryCover = await _consulHttpClient.GetAsync<AttachmentDTO>(_attachmentsMs, $"/api/Attachment/get/{page.Story.CoverId}");

            return Ok(res);
        }

        //GET: api/page/StoryPages/1
        [HttpGet("StoryPages/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPagesByStory([FromRoute] int id)
        {
            if (!_pageService.IsStoryExists(id))
            {
                return NotFound();
            }

            List<Page> storyPages = await _pageService.GetPagesByStory(id);
            return Ok(_mapper.Map<List<PageWithoutStoryDto>>(storyPages));
        }

        [HttpGet("getContent/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetContent([FromRoute] int id)
        {
            Page page = await _pageService.GetPageById(id);

            if (page == null)
            {
                return NotFound();
            }

            return Ok(page.Content);
        }

        //POST: api/page/add
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PostPage([FromBody] PageCreateDto pageCreateDto)
        {
            if (pageCreateDto == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorMessages.ModelStateParser(ModelState));
            }

            if (!_pageService.IsStoryExists(pageCreateDto.StoryId))
            {
                ModelState.AddModelError("page", ErrorMessages.INVALID_STORY_ID_VALUE);
                return BadRequest(ErrorMessages.ModelStateParser(ModelState));
            }

            Page pageEntity = _mapper.Map<Page>(pageCreateDto);

            _pageService.InsertPage(pageEntity);
            return CreatedAtAction("GetPage", new { id = pageEntity.PageId }, _mapper.Map<PageDto>(pageEntity));
        }

        //POST: api/page/add
        [HttpPost("addIn/{index}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult PostPage([FromBody] PageCreateDto pageCreateDto, [FromRoute] int index)
        {
            if (pageCreateDto == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorMessages.ModelStateParser(ModelState));
            }

            if (!_pageService.IsStoryExists(pageCreateDto.StoryId))
            {
                ModelState.AddModelError("page", ErrorMessages.INVALID_STORY_ID_VALUE);
                return BadRequest(ErrorMessages.ModelStateParser(ModelState));
            }

            Page pageEntity = _mapper.Map<Page>(pageCreateDto);

            _pageService.InsertPageIn(pageEntity, index);
            return CreatedAtAction("GetPage", new { id = pageEntity.PageId }, _mapper.Map<PageDto>(pageEntity));
        }

        // PUT: api/page/update
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutPage([FromBody] PageUpdateDto pageUpdateDto)
        {
            if (pageUpdateDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ErrorMessages.ModelStateParser(ModelState));
            }

            Page oldPage = await _pageService.GetPageById(pageUpdateDto.PageId);

            if (oldPage == null)
            {
                return NotFound();
            }

            Page pageEntity = _mapper.Map<Page>(pageUpdateDto);
            _pageService.UpdatePage(pageEntity, oldPage);

            return NoContent();
        }



        // PUT: api/page/3/add-image
        [HttpPut("{id}/add-image")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddImage([FromRoute] int id, [FromForm] int attachmentId)
        {

            if (attachmentId < 1)
            {
                ModelState.AddModelError("attachmentId", "attachmentId has not valid value");
                return BadRequest(ErrorMessages.ModelStateParser(ModelState));
            }

            AttachmentDTO res = _consulHttpClient.GetAsync<AttachmentDTO>(_attachmentsMs, $"/api/Attachment/get/{attachmentId}").GetAwaiter().GetResult();
            if (res == null)
            {
                ModelState.AddModelError("attachmentId", "No attachment has this id");
            }

            Page page = _pageService.GetPageById(id).GetAwaiter().GetResult();
            if (page == null)
            {
                ModelState.AddModelError("id", "No page has this id");
            }

            if (ModelState.ErrorCount > 0)
            {
                return BadRequest(ErrorMessages.ModelStateParser(ModelState));
            }

            page.ImageId = attachmentId;
            _pageService.UpdatePage(page);

            return NoContent();
        }

        // DELETE: api/page/delete/1
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeletePage([FromRoute] int id)
        {
            var page = _pageService.GetPageById(id).Result;
            if (page == null)
            {
                return NotFound();
            }

            _pageService.Delete(page);

            return NoContent();
        }
    }
}