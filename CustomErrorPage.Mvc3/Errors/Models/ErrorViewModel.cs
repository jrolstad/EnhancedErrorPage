using System;
using System.Collections.Generic;

namespace CustomErrorPage.Mvc3.Errors.Models
{
    public class ErrorViewModel
    {
        public string PageTitle { get; set; }

        public ExceptionViewModel RootException { get; set; }

        public Stack<ExceptionViewModel> Exceptions { get; set; }

        public string MachineName { get; set; }

        public string ServerUserName { get; set; }

        public DateTime ServerTime { get; set; }

        public string ControllerName { get; set; }

        public string ActionName { get; set; }

        public string RequestingUrl { get; set; }

        public string RequestContentType { get; set; }

        public string RequestContentEncoding { get; set; }

        public string RequestHttpMethod { get; set; }

        public IEnumerable<RequestValueViewModel> RequestServerVariables { get; set; }
 
        public IEnumerable<RequestValueViewModel> RequestCookies { get; set; } 

        public IEnumerable<RequestValueViewModel> RequestFormValues { get; set; }

        public IEnumerable<RequestValueViewModel> RequestHeaderValues { get; set; }

        public string RequestingUserName { get; set; }
    }
}