using System;
using System.Web;

namespace CustomErrorPage.Mvc3.Errors.Models
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
                var url = String.Format(@"https://www.google.com/search?q={0}",encodedText);

                return url;
            }
        }
    }
}