using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace iread_story.Web.Util
{
    public class ErrorMessages
    {
        public const String TAG_TITLE_UNIQUE = "Title is exist.";
        public const String TAG_TITLE_REQUIRED = "Title is required.";
        public const String STORY_ID_REQUIRED = "Story id is required.";
        public const String INVALID_STORY_ID_VALUE = "Invalid story id value.";
        public const String FILE_EXTENSION_NOT_ALLOWED = "File extension is not allowed!.";
        public const String AUDIO_FILE_EXTENSION_NOT_ALLOWED = "Audio file extension is not allowed, Must be MP3!.";
        public const String COVER_FILE_EXTENSION_NOT_ALLOWED = "Cover file extension is not allowed, Must be png or jpg!.";

        public static List<String> ModelStateParser(ModelStateDictionary modelStateDictionary)
        {
            return modelStateDictionary.Values.SelectMany(x => x.Errors.Select(y => y.ErrorMessage)).ToList();
        }
    }
}