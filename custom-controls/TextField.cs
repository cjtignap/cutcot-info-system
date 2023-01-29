using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cutcot_info_system.custom_controls
{
    public class TextField : Panel
    {
       

        TextField()
        {
            TextBox textBox = new TextBox();
            this.Controls.Add(textBox);
            textBox.Dock = DockStyle.Fill;
        }
    }
}
