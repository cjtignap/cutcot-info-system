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
    public partial class ImageViewer : Form
    {
        public ImageViewer(Image image)
        {
            InitializeComponent();
            this.TopMost = true;
            pictureBox1.Height = image.Height;
            pictureBox1.Width = image.Width;
            pictureBox1.Image = image;
        }
    }
}
