using Business_Manager_UI.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Manager_UI.Controllers
{
    class Controller
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
                int salesmenCount = 0;
                Salesman manager = null;

                try
                {
                    nr = (string)json.SelectToken(string.Format("Districts[{0}].Nr", i));
                    name = (string)json.SelectToken(string.Format("Districts[{0}].Name", i));

                    string managerId = (string)json.SelectToken(string.Format("Districts[{0}].Manager.Id", i));
                    string managerName = (string)json.SelectToken(string.Format("Districts[{0}].Manager.Name", i));
                    manager = new Salesman(managerId, managerName);
                    
                    salesmenCount = json.SelectToken(string.Format("Districts[{0}].Salesmen", i)).Count();
                }
                catch (Exception e)
                {
                    throw e;
                }

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

                List<Store> stores = new List<Store>();
                int storeCount = 0;
                try
                {
                    storeCount = json.SelectToken(string.Format("Districts[{0}].Stores", i)).Count();
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
                        storeId = (string)json.SelectToken(string.Format("Districts[{0}].Stores[{1}].Id", i, k));
                        storeName = (string)json.SelectToken(string.Format("Districts[{0}].Stores[{1}].Name", i, k));
                        s = new Store(storeId, storeName);
                        stores.Add(s);
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }

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
    }
}
