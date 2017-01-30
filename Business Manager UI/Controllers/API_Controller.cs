using Business_Manager_UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json.Linq;
using static Newtonsoft.Json.Linq.JObject;
using Newtonsoft.Json;

namespace Business_Manager_UI.Controllers
{
    public class API_Controller
    {
        string url = "http://localhost:58436/";
        string urlParams = "";

        public API_Controller(){}

        public string GetAllDistricts()
        {
            string districtsAsString = null;
            HttpResponseMessage response = null;

            urlParams = "api/District";
            
            try
            {
                response = SendHttpGet(urlParams);
                districtsAsString = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                throw e;
            }

            return districtsAsString;
        }

        public string GetDistrictDetails(string nr)
        {
            string districtAsString = null;
            HttpResponseMessage response = null;

            urlParams = "api/District?nr=" + nr;
            
            try
            {
                response = SendHttpGet(urlParams);
                // Parse the response body. Blocking!
                districtAsString = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                throw e;
            }

            return districtAsString;
        }

        public string GetAvailableSalesmen(string excludeDistrict)
        {
            string salesmenAsString = null;
            HttpResponseMessage response = null;

            urlParams = "api/Salesman?excludeDistrict=" + excludeDistrict;

            try
            {
                response = SendHttpGet(urlParams);
                salesmenAsString = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                throw e;
            }

            return salesmenAsString;
        }

        public string UpdateDistrict(string districtNr, string salesmanId, bool? manager)
        {
            HttpResponseMessage response = null;
            string stringResponse = null;

            urlParams = string.Format("api/District?districtNr={0}&salesmanId={1}&manager={2}", districtNr, salesmanId, manager);

            try
            {
                response = SendHttpPost(urlParams, null);
                stringResponse = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                throw e;
            }

            return stringResponse;
        }

        private HttpResponseMessage SendHttpGet(string parameter)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    return client.GetAsync(parameter).Result;  // Blocking call!
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //Unfinished. Does not work!
        private HttpResponseMessage SendHttpPost(string parameter, JObject data)
        {
            //throw new NotImplementedException("Check comment above");
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpContent content = null;
                    return client.PostAsync(parameter, content).Result;
                    //return client.PostAsync(parameter, content).Result;  // Blocking call!
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
