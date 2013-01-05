using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Index()
        {

            using (var connection = new SqlConnection(@"Server=sea-2400-02\dev;Database=invalidDB;Trusted_Connection=True;"))
            {
                try
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
                   
                }
                finally
                {
                    connection.Close();
                }
            }
            return View();
        }

    }
}
