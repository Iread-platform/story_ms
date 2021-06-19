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

        public static List<String> ModelStateParser(ModelStateDictionary modelStateDictionary)
        {
            return modelStateDictionary.Values.SelectMany(x => x.Errors.Select(y => y.ErrorMessage)).ToList();
        }
    }
}