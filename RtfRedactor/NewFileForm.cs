using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace RtfRedactor
{
    public partial class NewFileForm : Form
    {
        public string fileName = "";
        public NewFileForm()
        {
            InitializeComponent();
        }

        private void NewFileForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            fileName = textBox1.Text;
        }
    }
}
