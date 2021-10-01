using iread_story.DataAccess.Data;
using iread_story.DataAccess.Interface;
using iread_story.Web.Service;

namespace iread_story.DataAccess.Repository
{
    public class PublicRepository : IPublicRepository
    {
        private readonly AppDbContext _context;

        private IStoryRepository _storyRepository;
        private IPageRepository _pageRepository;
        private ILanguageRepo _laILanguageRepo;

        public PublicRepository(AppDbContext context)
        {
            _context = context;
        }

        public IStoryRepository GetStoryService
        {
            get
            {
                return _storyRepository ??= new StoryRepository(_context);
            }
        }

        public IPageRepository GetPageRepository
        {
            get
            {
                return _pageRepository ??= new PageRepository(_context);
            }
        }


        public ILanguageRepo GetLanguageRepo
        {
            get
            {
                return _laILanguageRepo ??= new LanguageRepo(_context);
            }
        }
    }
}