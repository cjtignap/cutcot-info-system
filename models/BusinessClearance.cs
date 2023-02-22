using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cutcot_info_system.models
{
    public class BusinessClearance
    {
        public string name { get; set; }
        public string business { get; set; }
        public string address { get; set; }
        public string month { get; set; }
        public string date { get; set; }
        public string request_no { get; set; }

        public BusinessClearance(string name, string business, string address, string month, string date, string request_no)
        {
            this.name = name;
            this.business = business;
            this.address = address;
            this.month = month;
            this.date = date;
            this.request_no = request_no;
        }

        public BusinessClearance()
        {
        }
    }
}
