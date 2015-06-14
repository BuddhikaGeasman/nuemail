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

        private void testing1()
        {
            HTag tag1 = new HTag("html");
            HTag tag2 = new HTag("p","para1",new String[1]{"align"},new String[1]{"\"left\""});
            HTag tag3 = new HTag("a",new string[1]{"alt"},new string[1]{"\"www.w3.org\""});
            HTag tag4 = new HTag("div", "\"float:right\"");
            CSSScript script1 = new CSSScript("class1");
            script1.addParam("Colour", "\"#FF0099\"");
            CSSScript script2 = new CSSScript("class2","Float","Left");
            script2.addParam("Colour", "\"#FF0099\"");

            label1.Text = tag1.ToString();
            label2.Text = tag2.ToString();
            label3.Text = tag3.ToString();
            label4.Text = tag4.ToString();
            label5.Text = script1.ToString();
            label6.Text = script2.ToString();
        }

        private void testing2()
        {
            HCode code1 = new HCode();

            code1.addHeadTag();
            code1.addBodyTag(); // Flag bits are yet not added
            

            label1.Text = code1.getHTMLCode();
        }

        private void testing3()
        {
            HEDocument etemp = new HEDocument();
            etemp.insertMainTable(2,new int[]{1,1});
            label2.Text = etemp.InlineHTML();
        }

        private void TemplateChooser_Load(object sender, EventArgs e)
        {
            testing3();
        }
    }
}
