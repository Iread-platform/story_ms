using iread_story.DataAccess.Service;
using Microsoft.AspNetCore.Mvc;

namespace iread_story.Web.Controller
{
    [Route("/api/[controller]")]
    public class PageController:ControllerBase
    {
        private readonly PageService _pageService;

        public PageController(PageService pageService)
        {
            _pageService = pageService;
        }
    }
}