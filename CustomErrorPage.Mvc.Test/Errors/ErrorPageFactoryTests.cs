using System;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using CustomErrorPage.Mvc3.Errors;
using CustomErrorPage.Mvc3.Errors.Models;
using NUnit.Framework;

namespace CustomErrorPage.Mvc.Test.Errors
{
    [TestFixture]
    public class ErrorPageFactoryTests
    {
        private HandleErrorInfo _error;
        private HttpRequest _request;
        private ErrorViewModel _result;

        [TestFixtureSetUp]
        public void BeforeAll()
        {
            var innerException = new ApplicationException("uh oh!");
            var exception = new Exception("something bad", innerException);

            _error = new HandleErrorInfo(exception, "some controller", "some action");

            _request = new HttpRequest("","http://github.com","");

            var factory = new ErrorPageFactory(_request);

            _result = factory.Build(_error);
        }


        [Test]
        public void Then_the_action_name_is_the_name_of_the_failing_action()
        {
            // Assert
            Assert.That(_result.ActionName,Is.EqualTo("some action"));
        }


        [Test]
        public void Then_the_controller_name_is_the_name_of_the_failing_controller()
        {
            // Assert
            Assert.That(_result.ControllerName,Is.EqualTo("some controller"));
        }


        [Test]
        public void Then_all_exceptions_are_obtained()
        {
            // Assert
            Assert.That(_result.Exceptions.Select(e=>e.Message).ToArray(),Is.EquivalentTo(new[]{_error.Exception.Message,_error.Exception.InnerException.Message}));
        }


        [Test]
        public void Then_the_root_exception_is_found()
        {
            // Assert
            Assert.That(_result.RootException.Message,Is.SameAs(_error.Exception.InnerException.Message));
        }

        [Test]
        public void Then_the_machine_name_is_the_current_machine()
        {
            // Assert
            Assert.That(_result.MachineName,Is.EqualTo(Environment.MachineName));
        }

        [Test]
        public void Then_the_request_content_encoding_is_read()
        {
            // Assert
            Assert.That(_result.RequestContentEncoding,Is.Not.Null);
        }

        [Test]
        public void Then_the_request_content_type_is_read()
        {
            // Assert
            Assert.That(_result.RequestContentType, Is.Not.Null);
        }

        [Test]
        public void Then_the_request_cookies_are_read()
        {
            // Assert
            Assert.That(_result.RequestCookies.Count(), Is.EqualTo(_request.Cookies.Count));
        }

        [Test]
        public void Then_the_request_form_values_are_read()
        {
            // Assert
            Assert.That(_result.RequestFormValues.Count(), Is.EqualTo(_request.Form.Count));
        }

        [Test]
        public void Then_the_request_header_values_are_read()
        {
            // Assert
            Assert.That(_result.RequestHeaderValues.Count(), Is.EqualTo(_request.Headers.Count));
        }

        [Test]
        public void Then_the_request_http_method_is_read()
        {
            // Assert
            Assert.That(_result.RequestHttpMethod, Is.EqualTo(_request.HttpMethod));
        }

        [Test]
        public void Then_the_request_server_variables_are_read()
        {
            // Assert
            Assert.That(_result.RequestServerVariables, Is.Not.Null);
        }

        [Test]
        public void Then_the_request_url_is_read()
        {
            // Assert
            Assert.That(_result.RequestingUrl, Is.EqualTo(_request.Url.AbsolutePath));
        }

        [Test]
        public void Then_the_requesting_user_name_is_the_name_of_the_reqeusting_user()
        {
            // Assert
            Assert.That(_result.RequestingUserName, Is.Not.Null);
        }

        [Test]
        public void Then_the_server_time_is_the_current_time()
        {
            // Assert
            Assert.That(_result.ServerTime.Date, Is.EqualTo(DateTime.Today));
        }

        [Test]
        public void Then_the_server_user_is_obtained()
        {
            // Assert
            Assert.That(_result.ServerUserName, Is.StringContaining(Environment.UserDomainName));
            Assert.That(_result.ServerUserName, Is.StringContaining(Environment.UserName));
        }


    }
}