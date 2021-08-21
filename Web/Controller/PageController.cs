using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using iread_story.DataAccess.Data.Entity;
using iread_story.Web.Service;
using iread_story.Web.DTO.Page;
using iread_story.Web.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iread_story.Web.Controller
{
    [Route("/api/Story/[controller]")]
    public class PageController : ControllerBase
    {
        private readonly PageService _pageService;
        private readonly IMapper _mapper;

        public PageController(PageService pageService, IMapper mapper)
        {
            _pageService = pageService;
            _mapper = mapper;
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

            return Ok(_mapper.Map<PageDto>(page));
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

            if (!_pageService.UpdatePage(pageEntity, oldPage))
            {
                return BadRequest();
            }

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