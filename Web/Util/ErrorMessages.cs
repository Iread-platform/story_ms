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
        public const String PAGE_ID_REQUIRED = "Page id is required.";
        public const String PAGE_CONTENT_REQUIRED = "Page content is required.";
        public const String INVALID_PAGE_ID_VALUE = "Invalid page id value";
        public const String COLOR_REQUIRED = "Color is required.";
        public const String NOT_OWNER = "You are not the owner of this story.";
        public const String LANGUAGE_INVALID_NAME = "Only characters are allowed a-z A-Z.";
        public const String LANGUAGE_INVALID_CODE = "Only lower case characters are allowed a-z.";
        public const String LANGUAGE_EXISTS = "Language already exists.";
        public const String LANGUAGE_NOT_EXISTS = "Language Does not exist.";
        public const String LANGUAGE_NOT_DELETED = "Language was not deleted.";
        public const String LANGUAGE_NOT_ACTIVE = "Language is not supported.";

        public const String QUESTION_ID_NOT_FOUND = "Question id not found.";


        public static List<String> ModelStateParser(ModelStateDictionary modelStateDictionary)
        {
            return modelStateDictionary.Values.SelectMany(x => x.Errors.Select(y => y.ErrorMessage)).ToList();
        }
    }
}