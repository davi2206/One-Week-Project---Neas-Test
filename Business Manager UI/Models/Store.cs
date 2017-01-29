using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Manager_UI.Models
{
    public class Store
    {
        public Store(string id, string name)
        {
            Id = id;
            Name = name;
        }
        
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
