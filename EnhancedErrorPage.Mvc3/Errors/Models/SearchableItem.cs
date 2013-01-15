using System;
using System.Web;

namespace EnhancedErrorPage.Mvc3.Errors.Models
{
    public class SearchableItem
    {
        public SearchableItem(string text)
        {
            Text = text;
        }

        public string Text { get; private set; }

        public string SearchUrl
        {
            get
            {
                var encodedText = HttpUtility.UrlEncode(Text);
                const string googleSearchUrl = @"https://www.google.com/search?q={0}";

                var url = String.Format(googleSearchUrl,encodedText);

                return url;
            }
        }
    }
}