using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Manager_UI.Models
{
    public class District
    {
        public District(string nr, string name, Salesman manager, List<Salesman> salesmen, List<Store> stores)
        {
            Nr = nr;
            Name = name;
            Manager = manager;
            Salesmen = salesmen;
            Stores = stores;
        }

        public string Nr { get; set; }
        public string Name { get; set; }
        public Salesman Manager { get; set; }
        public List<Salesman> Salesmen { get; set; }
        public List<Store> Stores { get; set; }
    }
}
