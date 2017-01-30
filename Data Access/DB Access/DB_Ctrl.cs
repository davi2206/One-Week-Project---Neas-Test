using Data_Access_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.DB_Access
{
    /// <summary>
    /// Controls the data for the database
    /// </summary>
    public class DB_Ctrl
    {
        DB_Connection db_con;

        public DB_Ctrl()
        {
            db_con = new DB_Connection();
        }

        public List<District> GetAllDistricts()
        {
            try
            {
                List<District> districts = db_con.GetAllDistricts();
                return districts;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public District GetDistrict(string nr)
        {
            try
            {
                District district = db_con.GetDistrict(nr);
                return district;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Salesman> GetAvailableSalesmen(string excludeDistrict)
        {
            try
            {
                return db_con.GetAvailableSalesmen(excludeDistrict);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool UpdateDistrict(string districtNr, string salesmanId, bool manager)
        {
            try
            {
                return db_con.UpdateDistrict(districtNr, salesmanId, manager);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
