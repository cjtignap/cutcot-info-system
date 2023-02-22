using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cutcot_info_system.models
{
    public class WaterClearance
    {
        public  string name { get; set; }
        public string age { get; set; }
        public DateOnly birthdate { get; set; }
        public string address { get; set; }
        public string date { get; set; }
        public string month { get; set; }
        public string request_no { get; set; }
        public WaterClearance(string name, string age, DateOnly birthdate, string address, string date, string month,string request_no)
        {
            this.name = name;
            this.age = age;
            this.birthdate = birthdate;
            this.address = address;
            this.date = date;
            this.month = month;
            this.request_no = request_no;
        }

        public WaterClearance()
        {
        }
    }
}
