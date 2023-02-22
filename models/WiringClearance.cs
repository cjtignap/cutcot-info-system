using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cutcot_info_system.models
{
    public class WiringClearance
    {
        public string name { get; set; }
        public string age { get; set; }
        public DateOnly birthDate { get; set; }
        public string address { get; set; }
        public string month { get; set; }
        public string date { get; set; }

        public string request_no { get; set; }

        public WiringClearance(string name, string age, DateOnly birthDate, string address, string month, string date, string request_no)
        {
            this.name = name;
            this.age = age;
            this.birthDate = birthDate;
            this.address = address;
            this.month = month;
            this.date = date;
            this.request_no = request_no;
        }

        public WiringClearance()
        {
        }
    }
}
