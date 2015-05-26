using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace nuemail
{
    public partial class TemplateChooser : Form
    {
        public TemplateChooser()
        {
            InitializeComponent();
        }

        private void TemplateChooser_Load(object sender, EventArgs e)
        {
            HTag tag1 = new HTag("html");
            HTag tag2 = new HTag("p","para1",new String[1]{"align"},new String[1]{"\"left\""});
            HTag tag3 = new HTag("a",new string[1]{"alt"},new string[1]{"www.w3.org"});
            HTag tag4 = new HTag("div", "\"float:right\"");

            label1.Text = tag1.ToString();
            label2.Text = tag2.ToString();
            label3.Text = tag3.ToString();
            label4.Text = tag4.ToString();
        }
    }
}
