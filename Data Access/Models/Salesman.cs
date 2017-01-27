using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Server.Models
{
    [DataContract]
    public class Salesman
    {
        public Salesman(string id, string name)
        {
            Id = id;
            Name = name;
        }

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
