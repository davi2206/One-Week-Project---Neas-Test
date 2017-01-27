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
    class API_Controller
    {
        string url = "http://localhost:58436/";
        string urlParams = "";

        public API_Controller()
        {
        }

        public string GetAllDistricts()
        {
            string districtsAsString = null;
            HttpResponseMessage response = null;

            string urlParams = "api/District";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    response = client.GetAsync(urlParams).Result;  // Blocking call! 
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            try
            {
                // Parse the response body. Blocking!
                districtsAsString = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                throw e;
            }

            return districtsAsString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nr"></param>
        /// <returns></returns>
        public string GetDistrictDetails(string nr)
        {
            string districtAsString = null;
            HttpResponseMessage response = null;

            string urlParams = "api/District/" + nr;

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    response = client.GetAsync(urlParams).Result;  // Blocking call! 
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            try
            {
                // Parse the response body. Blocking!
                districtAsString = response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                throw e;
            }

            return districtAsString;
        }
    }
}
