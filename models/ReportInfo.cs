﻿    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cutcot_info_system.models
{
    public class ReportInfo
    {
        public string report_type { get; set; }
        public string nature_of_dispute { get; set; }
        public int page_no { get; set; }
        public string case_no { get; set; }
        public string record_photo { get; set; }

        public Hearing firstHearing { get; set; }
        public Hearing secondHearing { get; set; }
        public Hearing thirdHearing { get; set; }

        public PartyInformation first_party_info { get; set; }
        public PartyInformation second_party_info { get; set; }
        public DateTime date { get; set; }

        public string status { get; set; }

        public ReportInfo() { }

        public ReportInfo(string report_type, 
            string nature_of_dispute,
            int page_no, string case_no, 
            string record_photo, 
            Hearing firstHearing,
            Hearing secondHearing,
            Hearing thirdHearing,
            PartyInformation first_party_info,
            PartyInformation second_party_info, 
            DateTime date,
            string status)
        {
            this.report_type = report_type;
            this.nature_of_dispute = nature_of_dispute;
            this.page_no = page_no;
            this.case_no = case_no;
            this.record_photo = record_photo;
            this.firstHearing = firstHearing;
            this.secondHearing = secondHearing;
            this.thirdHearing = thirdHearing;
            this.first_party_info = first_party_info;
            this.second_party_info = second_party_info;
            this.date = date;
            this.status = status;

        }
    }

}