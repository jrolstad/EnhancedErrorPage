using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models.Errors;

namespace MvcApplication1.Errors
{
    public class ErrorPageFactory
    {
        private readonly HttpContext _context;
        private HttpRequest _request;

        public ErrorPageFactory(HttpContext context)
        {
            _context = context;
            _request = context.Request;
        }

        public ErrorViewModel Build(HandleErrorInfo error)
        {
            ICollection<ExceptionViewModel> exceptions;
            IEnumerable<RequestValueViewModel> cookies;
            IEnumerable<RequestValueViewModel> formValues;
            ExceptionViewModel rootException;
            IEnumerable<RequestValueViewModel> serverVariables;

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
    }
}