using System;
using System.Collections.Generic;

namespace MvcApplication1.Models.Errors
{
    public class ExceptionViewModel
    {
        public Type Type { get; set; }

        public string Message { get; set; }

        public string Source { get; set; }

        public ICollection<string> StackTrace { get; set; }

        public string SearchUrl { get; set; }
    }
}