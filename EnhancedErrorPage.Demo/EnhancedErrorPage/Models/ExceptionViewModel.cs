using System.Collections.Generic;

namespace EnhancedErrorPage.Mvc3.Errors.Models
{
    public class ExceptionViewModel
    {
        public SearchableItem Type { get; set; }

        public SearchableItem Message { get; set; }

        public SearchableItem Source { get; set; }

        public IEnumerable<SearchableItem> StackTrace { get; set; }
    }
}