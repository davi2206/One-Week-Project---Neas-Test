using Data_Access_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Server.Models
{
    [DataContract]
    public class District
    {

        public District(string nr, string name, Salesman manager)
        {
            Nr = nr;
            Name = name;
            Manager = manager;
        }

        [DataMember]
        public string Nr { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Salesman Manager { get; set; }

        [DataMember]
        public List<Salesman> Salesmen { get; set; }

        [DataMember]
        public List<Store> Stores { get; set; }
    }
}
