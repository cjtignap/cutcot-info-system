using cutcot_info_system.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cutcot_info_system.pop_ups
{
    public partial class AddHearing : Form
    {


        public Hearing hearing { get; set; }
        public AddHearing()
        {
            InitializeComponent();
        }

       

        private void AddHearing_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Hearing hearing2 = new Hearing();
            hearing2.remarks = txtRemarks.Text;
            hearing2.hearingSchedule = DateOnly.FromDateTime(dateHearing.Value.Date);
            this.hearing = hearing2;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }

    
}
