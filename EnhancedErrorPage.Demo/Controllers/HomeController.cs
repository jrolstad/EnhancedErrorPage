using System;
using System.Net;
using System.Web.Mvc;

namespace EnhancedErrorPage.Demo.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            try
            {
                using (var client = new WebClient())
                {
                    // Try to download from somewhere that does not exist
                    var url = string.Format("http://{0}", Guid.NewGuid().ToString());
                    var response = client.DownloadString(url);

                    return Json(response, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception exception)
            {
                var meaningfulException = new ApplicationException("Uh oh, something unexpected occured!", exception);
                throw meaningfulException;
            }
           

        }
    }
}
