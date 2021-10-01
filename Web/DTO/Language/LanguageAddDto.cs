using System.ComponentModel.DataAnnotations;
using iread_story.Web.Util;


namespace iread_story.Web.DTO.Language
{
    public class LanguageAddDto
    {

        [RegularExpression(@"[a-zA-Z]+",
                ErrorMessage = ErrorMessages.LANGUAGE_INVALID_NAME)]
        public string Name { get; set; }


        [RegularExpression(@"[a-z]+",
                ErrorMessage = ErrorMessages.LANGUAGE_INVALID_CODE)]
        public string Code { get; set; }
    }
}