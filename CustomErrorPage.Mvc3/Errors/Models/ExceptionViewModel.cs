using System;
using System.Collections.Generic;

namespace CustomErrorPage.Mvc3.Errors.Models
{
    public class ExceptionViewModel
    {
        public Type Type { get; set; }

        public string Message { get; set; }

        public string Source { get; set; }

        public IEnumerable<string> StackTrace { get; set; }

        public string SearchUrl { get; set; }
    }
}