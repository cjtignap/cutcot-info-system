using cutcot_info_system.printable_form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cutcot_info_system.forms
{
    public partial class ProcessDocument : Form
    {
        public ProcessDocument()
        {
            InitializeComponent();
            label1.BringToFront(); //plain label with bg color

            label2.SendToBack(); //label with a bg image
        }


        Bitmap original;
        Bitmap bitMaptoPrint;
        private void captureFromScreen()
        {
            
           original = new Bitmap(panel1.Width, panel1.Height);
           panel1.DrawToBitmap(original, new Rectangle(0, 0, panel1.Width, panel1.Height));
           bitMaptoPrint = new Bitmap(original,new Size(816, 1056));
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Rectangle m = new Rectangle(0, 0, 816, 1056);
            e.Graphics.DrawImage(bitMaptoPrint, m);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            captureFromScreen();
            printPreviewDialog1.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
