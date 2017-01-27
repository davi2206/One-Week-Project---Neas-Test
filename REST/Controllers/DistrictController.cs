using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data_Access_Server;
using Data_Access.Models;
using Data_Access.DB_Access;
using System.Windows;

namespace REST.Controllers
{
    public class DistrictController : ApiController
    {
        DB_Ctrl db_Ctrl = new DB_Ctrl();

        public IEnumerable<District> Get()
        {
            try
            {
                return db_Ctrl.GetAllDistricts();
            }
            catch (Exception exc)
            {
                LogEvent(exc.Message, 3);
                return null;
            }
        }

        public District Get(string nr)
        {
            try
            {
                return db_Ctrl.GetDistrict(nr);
            }
            catch (Exception exc)
            {
                LogEvent(exc.Message, 3);
                return null;
            }
        }

        /// <summary>
        /// Logging errors and information to a logfile
        /// </summary>
        /// <param name="logEvent">The event to be logged</param>
        /// <param name="logLevel">
        /// The level of the log:
        /// 0: Info
        /// 1: Debug
        /// 2: Warning
        /// 3: Error
        /// 4: Fatal
        /// </param>
        private void LogEvent(string logEvent, int logLevel = 0)
        {
            string level = "";

            switch (logLevel)
            {
                case 0:
                    level = "Info";
                    break;
                case 1:
                    level = "Debug";
                    break;
                case 2:
                    level = "Warning";
                    break;
                case 3:
                    level = "Error";
                    break;
                case 4:
                    level = "FATAL";
                    break;
                default:
                    level = "Unknown";
                    break;
            }

            string timestamp = DateTime.Now.ToShortTimeString();

            string logMessage = string.Format("[{0} - {1}]: {2}", timestamp, level, logEvent);

            string path = AppDomain.CurrentDomain.BaseDirectory + "\\LogREST.txt";

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
            {
                file.WriteLine(logMessage);
            }
        }
    }
}
