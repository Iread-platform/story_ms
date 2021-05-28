using System.Collections.Generic;
using iread_story.DataAccess.Data.Entity;

namespace iread_story.DataAccess.Interface
{
    public interface IStory
    {
        Story GetStory(int id);

        void AddStory(Story story);

        IEnumerable<Story> GetStories();

        void DeleteStory(int id);

        bool Exists(int id);

    }
}