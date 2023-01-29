using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cutcot_info_system.models
{
    public class PartyInformation
    {
        public string name { get; set; }
        public string address { get; set; }
        public string contact { get; set; }
        public int age { get; set; }

        public PartyInformation(string name, string address, string contact, int age)
        {
            this.name = name;
            this.address = address;
            this.contact = contact;
            this.age = age;
        }
        public PartyInformation() { }
    }
}
