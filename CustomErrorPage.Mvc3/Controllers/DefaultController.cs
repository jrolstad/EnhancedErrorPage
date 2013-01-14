using System;
using System.Web.Mvc;

namespace CustomErrorPage.Mvc3.Controllers
{
    public class DefaultController : Controller
    {
        public JsonResult Index()
        {
            try
            {
                var value1 = 1;
                var value2 = 0;

                var result = value1 / value2;

                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                var newException = new ApplicationException("oh oh, what happend?", e);
                throw newException;
            }
        }

    }
}
