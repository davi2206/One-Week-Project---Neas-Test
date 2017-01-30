using Data_Access.DB_Access;
using Data_Access_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace REST.Controllers
{
    public class SalesmanController : ApiController
    {
        DB_Ctrl db_Ctrl = new DB_Ctrl();

        public IEnumerable<Salesman> GET(string excludeDistrict)
        {
            try
            {
                return db_Ctrl.GetAvailableSalesmen(excludeDistrict);
            }
            catch (Exception exc)
            {
                //LogEvent(exc.Message, 3);
                return null;
            }
        }
    }
}
