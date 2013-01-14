using System;
using System.Collections.Generic;

namespace CustomErrorPage.Mvc3.Errors.Models
{
    public class ExceptionViewModel
    {
        public Type Type { get; set; }

        public SearchableItem Message { get; set; }

        public string Source { get; set; }

        public IEnumerable<SearchableItem> StackTrace { get; set; }
    }
}