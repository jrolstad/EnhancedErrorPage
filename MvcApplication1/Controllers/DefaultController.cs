using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using MvcApplication1.Models;

namespace MvcApplication1.Controllers
{
    public class DefaultController : Controller
    {
        public ActionResult Index()
        {

            using (var connection = new SqlConnection(@"Server=sea-2400-02\dev;Database=magnet_dev_joshr;Trusted_Connection=True;"))
            {
                try
                {
                    connection.Open();

                    try
                    {
                        var data = connection.Query<DataEntity>("select 1 d as Value");
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
