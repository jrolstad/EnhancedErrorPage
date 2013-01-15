using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomErrorPage.Mvc3.Errors.Models;

namespace CustomErrorPage.Mvc3.Errors
{
    public class ErrorPageFactory
    {
        private readonly HttpRequest _request;

        public ErrorPageFactory(HttpRequest request)
        {
            _request = request;
        }

        public ErrorViewModel Build(HandleErrorInfo error)
        {
            var exceptions = GetExceptionStack(error.Exception);
            var rootException = exceptions.First();

            var cookies = GetCookies(_request);
            var formValues = GetFormValues(_request);
            var serverVariables = GetServerVariables(_request);
            var headerValues = GetHeaderValues(_request);

            var requestContentEncoding = GetContentEncoding();
            var requestingUrl = _request.Url.AbsolutePath;

            var requestingUserName = GetRequestingUserName();

            var serverUserName = string.Format(@"{0}\{1}",Environment.UserDomainName, Environment.UserName);
            var machineName = Environment.MachineName;

            var model = new ErrorViewModel
                {
                    PageTitle = "Error",
                    ActionName = error.ActionName,
                    ControllerName = error.ControllerName,
                    Exceptions = exceptions,
                    MachineName = machineName,
                    RequestContentEncoding = requestContentEncoding,
                    RequestContentType = _request.ContentType,
                    RequestCookies = cookies,
                    RequestFormValues = formValues,
                    RequestHeaderValues = headerValues,
                    RequestHttpMethod = _request.HttpMethod,
                    RequestServerVariables = serverVariables,
                    RootException = rootException,
                    ServerUserName = serverUserName,
                    ServerTime = DateTime.Now,
                    RequestingUrl = requestingUrl,
                    RequestingUserName = requestingUserName

                };

            return model;
        }

        private string GetRequestingUserName()
        {
            try
            {
                var name = _request.RequestContext.HttpContext.User.Identity.Name;

                return name;
            }
            catch (Exception)
            {
                return "";
            }
        }

        private IEnumerable<RequestValueViewModel> GetHeaderValues(HttpRequest request)
        {
            return from key in request.Headers.AllKeys
                   let value = request.Headers[key]
                   select new RequestValueViewModel { Name = key, Value = value };
        }

        private string GetContentEncoding()
        {
            try
            {
                return _request.ContentEncoding.EncodingName;
            }
            catch (Exception)
            {
                return "";
            }
            
        }

        private Stack<ExceptionViewModel> GetExceptionStack(Exception exception)
        {
            var innerMostException = exception;

            var exceptionStack = new Stack<ExceptionViewModel>();

            var viewModel = Map(exception);
            exceptionStack.Push(viewModel);

            while (innerMostException.InnerException != null)
            {
                innerMostException = innerMostException.InnerException;
                var innerViewModel = Map(innerMostException);
                exceptionStack.Push(innerViewModel);
            }
            return exceptionStack;
        }

        private ExceptionViewModel Map(Exception exception)
        {
            return new ExceptionViewModel
                {
                    Message = new SearchableItem(exception.Message),
                    Source = new SearchableItem(exception.Source),
                    Type = new SearchableItem(exception.GetType().ToString()),
                    StackTrace = ReverseStackTrace(exception.StackTrace)
                };
        }

        private IEnumerable<SearchableItem> ReverseStackTrace(string stackTrace)
        {
            if (string.IsNullOrWhiteSpace(stackTrace))
                return new SearchableItem[0];

            var stackTraceLines = stackTrace.Split(Environment.NewLine.ToCharArray());
            var reversedTrace = stackTraceLines.Reverse();

            return reversedTrace.Select(t => new SearchableItem(t));
        }

        private IEnumerable<RequestValueViewModel> GetServerVariables(HttpRequest request)
        {
            return from key in request.ServerVariables.AllKeys 
                   let value = request.ServerVariables[key] 
                   select new RequestValueViewModel {Name = key, Value = value};
        }

        private IEnumerable<RequestValueViewModel> GetFormValues(HttpRequest request)
        {
            return from key in request.Form.AllKeys 
                   let value = request.Form[key] 
                   select new RequestValueViewModel {Name = key, Value = value};
        }

        private IEnumerable<RequestValueViewModel> GetCookies(HttpRequest request)
        {
            return from key in request.Cookies.AllKeys
                   let value = request.Cookies[key]
                   select new RequestValueViewModel {Name = key, Value = value.Value}
                ;
        }
    }
}