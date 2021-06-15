using iread_story.DataAccess.Data;
using iread_story.DataAccess.Interface;
using iread_story.DataAccess.Service;

namespace iread_story.DataAccess.Repository
{
    public class PublicRepository:IPublicRepository
    {
        private readonly AppDbContext _context;
        private IStory _storyService;

        public PublicRepository(AppDbContext context)
        {
            _context = context;
        }

        public IStory getStoryService {
            get
            {
                return _storyService ??= new StoryService(_context);
            }
        }
    }
}