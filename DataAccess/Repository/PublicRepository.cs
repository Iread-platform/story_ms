using iread_story.DataAccess.Data;
using iread_story.DataAccess.Interface;
using iread_story.Web.Service;

namespace iread_story.DataAccess.Repository
{
    public class PublicRepository:IPublicRepository
    {
        private readonly AppDbContext _context;
        private IStoryRepository _storyRepository;

        public PublicRepository(AppDbContext context)
        {
            _context = context;
        }

        public IStoryRepository GetStoryService {
            get
            {
                return _storyRepository ??= new StoryRepository(_context);
            }
        }
    }
}