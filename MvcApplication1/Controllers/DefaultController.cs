using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Index()
        {

           

                try
                {
                    var value1 = 1;
                    var value2 = 0;

                    var result = value1/value2;
                }
                catch (Exception e)
                {
                    var newException = new ApplicationException("oh oh, what happend?", e);
                    throw newException;
                }
                   
                

            
            return View();
        }

    }
}
