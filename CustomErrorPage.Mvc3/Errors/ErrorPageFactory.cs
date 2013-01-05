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

            var model = new ErrorViewModel
                {
                    PageTitle = "Error",
                    ActionName = error.ActionName,
                    ControllerName = error.ControllerName,
                    Exceptions = exceptions,
                    MachineName = Environment.MachineName,
                    RequestContentEncoding = _request.ContentEncoding.EncodingName,
                    RequestContentType = _request.ContentType,
                    RequestCookies = cookies,
                    RequestFormValues = formValues,
                    RequestHttpMethod = _request.HttpMethod,
                    RequestServerVariables = serverVariables,
                    RootException = rootException,
                    ServerUserName = Environment.UserName,
                    ServerTime = DateTime.Now,
                    RequestingUrl = _request.Url.AbsolutePath

                };

            return model;
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
                    Message = exception.Message,
                    Source = exception.Source,
                    Type = exception.GetType(),
                    StackTrace = ReverseStackTrace(exception.StackTrace)
                };
        }

        private IEnumerable<string> ReverseStackTrace(string stackTrace)
        {
            var stackTraceLines = stackTrace.Split(Environment.NewLine.ToCharArray());
            var reversedTrace = stackTraceLines.Reverse();

            return reversedTrace;
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
                   select new RequestValueViewModel {Name = key, Value = value.ToString()}
                ;
        }
    }
}