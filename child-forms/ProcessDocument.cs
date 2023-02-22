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
        }
        Bitmap original;
        Bitmap bitMaptoPrint;
        private void captureFromScreen()
        {
            //BarangayClearance brgyClearance = new BarangayClearance();
            //brgyClearance.Show();

           // original = new Bitmap(brgyClearance.Width, brgyClearance.Height);
           // brgyClearance.DrawToBitmap(original, new Rectangle(0, 0, brgyClearance.Width, brgyClearance.Height));
          //  bitMaptoPrint = new Bitmap(original,new Size(816, 1056));
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Rectangle m = new Rectangle(0, 0, 816, 1056);
            e.Graphics.DrawImage(bitMaptoPrint, m);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //captureFromScreen();
           // printPreviewDialog1.ShowDialog();
        }


    }
}
