using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace СашаКрисЛАБА8
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public int InputValue
        {
            get
            {
                int val;
                if (int.TryParse(textBox1.Text, out val))
                    return val;
                return 22;
            }
        }
    }
}
