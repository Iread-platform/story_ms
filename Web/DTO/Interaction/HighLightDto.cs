using System;
using System.ComponentModel.DataAnnotations;

namespace iread_story.Web.Dto.Interaction
{
    public class HighLightDto
    {
        public int HighLightId { get; set; }
        public InnerInteractionDto Interaction { get; set; }

        public int FirstWordIndex { get; set; }

        public int EndWordIndex { get; set; }

        public string FirstWord { get; set; }

        public string EndWord { get; set; }

    }
}