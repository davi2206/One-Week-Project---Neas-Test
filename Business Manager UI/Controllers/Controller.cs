using Business_Manager_UI.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Manager_UI.Controllers
{
    public class Controller
    {
        API_Controller apiCtrl;

        public Controller()
        {
            apiCtrl = new API_Controller();
        }

        public List<District> GetAllDistricts()
        {
            List<District> districts = new List<District>();
            string districtsAsString = "";
            string stringObjects = "";
            JObject json = null;
            int districtsCount = 0;

            try
            {
                districtsAsString = apiCtrl.GetAllDistricts();

                stringObjects = "{\"Districts\":" + districtsAsString + "}";
                json = JObject.Parse(stringObjects);

                districtsCount = json.SelectToken("Districts").Count();
            }
            catch (Exception e)
            {
                throw e;
            }

            for (int i = 0; i < districtsCount; i++)
            {
                string nr = "";
                string name = "";

                List<Salesman> salesmen = new List<Salesman>();
                Salesman manager = null;

                try
                {
                    nr = (string)json.SelectToken(string.Format("Districts[{0}].Nr", i));
                    name = (string)json.SelectToken(string.Format("Districts[{0}].Name", i));

                    string managerId = (string)json.SelectToken(string.Format("Districts[{0}].Manager.Id", i));
                    string managerName = (string)json.SelectToken(string.Format("Districts[{0}].Manager.Name", i));
                    manager = new Salesman(managerId, managerName);
                }
                catch (Exception e)
                {
                    throw e;
                }

                salesmen = GetSalesmenInDistrict(i, json);

                List<Store> stores = GetStoresInDistrict(i, json);

                try
                {
                    District d = new District(nr, name, manager, salesmen, stores);
                    districts.Add(d);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return districts;
        }

        /// <summary>
        /// Get all the salesmen in the district
        /// </summary>
        /// <param name="i">Nr for district</param>
        /// <param name="json">JObject with all data</param>
        /// <returns>List of Salesman objects</returns>
        private List<Salesman> GetSalesmenInDistrict(int i, JObject json)
        {
            int salesmenCount = json.SelectToken(string.Format("Districts[{0}].Salesmen", i)).Count();
            List<Salesman> salesmen = new List<Salesman>();

            for (int j = 0; j < salesmenCount; j++)
            {
                try
                {
                    string salesmanId = (string)json.SelectToken(string.Format("Districts[{0}].Salesmen[{1}].Id", i, j));
                    string salesmanName = (string)json.SelectToken(string.Format("Districts[{0}].Salesmen[{1}].Name", i, j));
                    Salesman s = new Salesman(salesmanId, salesmanName);
                    salesmen.Add(s);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return salesmen;
        }

        /// <summary>
        /// Gets all stores in District
        /// </summary>
        /// <param name="districtNr">Nr for district</param>
        /// <param name="json">JObject with all data</param>
        /// <returns>List of Store objects</returns>
        private List<Store> GetStoresInDistrict(int districtNr, JObject json)
        {
            List<Store> stores = new List<Store>();

            int storeCount = 0;
            try
            {
                storeCount = json.SelectToken(string.Format("Districts[{0}].Stores", districtNr)).Count();
            }
            catch (Exception e)
            {
                throw e;
            }

            for (int k = 0; k <= storeCount; k++)
            {
                string storeId = "";
                string storeName = "";
                Store s = null;

                try
                {
                    storeId = (string)json.SelectToken(string.Format("Districts[{0}].Stores[{1}].Id", districtNr, k));
                    storeName = (string)json.SelectToken(string.Format("Districts[{0}].Stores[{1}].Name", districtNr, k));
                    s = new Store(storeId, storeName);
                    stores.Add(s);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            return stores;
        }
    }
}
