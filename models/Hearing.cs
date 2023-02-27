using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cutcot_info_system.models
{
   public class Hearing
    {
        public Hearing()
        {

        }
        public Hearing(int id, DateOnly hearingSchedule, string remarks)
        {
            Id = id;
            this.hearingSchedule = hearingSchedule;
            this.remarks = remarks;
        }

        public int Id { get; set; }
        public DateOnly hearingSchedule { get; set; }
        public string remarks { get; set; }

    }
}
