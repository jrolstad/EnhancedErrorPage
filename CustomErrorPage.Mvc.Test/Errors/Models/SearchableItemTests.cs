using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using Directus.CustomErrorPage.Mvc3.Errors.Models;
using NUnit.Framework;

namespace Directus.CustomErrorPage.Mvc.Test.Errors.Models
{
    [TestFixture]
    public class SearchableItemTests
    {

        [Test]
        public void The_Search_url_searches_google()
        {
            // Arrange
            const string text = "something bad";

            var item = new SearchableItem(text);

            // Act
            var result = item.SearchUrl;

            // Assert
            Assert.That(result, Is.StringContaining("google.com/search"));
        }

        [Test]
        public void The_Search_url_searches_for_the_text()
        {
            // Arrange
            var text = "something bad";

            var item = new SearchableItem(text);

            // Act
            var result = item.SearchUrl;

            // Assert
            Assert.That(result, Is.StringContaining(HttpUtility.UrlEncode(text)));
        } 

    }
}