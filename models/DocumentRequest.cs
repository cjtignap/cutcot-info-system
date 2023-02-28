using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cutcot_info_system.models
{
    internal class DocumentRequest
    {
        public DocumentRequest(int id, string docType, string requestBy, string status)
        {
            this.id = id;
            this.docType = docType;
            this.requestBy = requestBy;
            this.status = status;
        }
        public DocumentRequest()
        {

        }
        public int id { get; set; }    
        public string docType { get; set; }
        public string requestBy { get; set; }
        public string status { get; set; }
    }
}
