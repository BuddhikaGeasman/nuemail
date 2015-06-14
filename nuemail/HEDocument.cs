using System;
using System.Collections.Generic;
using System.Text;

namespace nuemail
{
    public class HEDocument
    {
        // Definition of an HTML code
        HCode docCode;

        // Initialize HTML code to have body
        public HEDocument()
        {
            docCode=new HCode();
            docCode.addBodyTag();
            docCode.addHeadTag();
        }

        // Inserting a table to the web page
        public void insertMainTable(int numOFColumns, int[] columnSizes)
        {
            if (numOFColumns != columnSizes.Length)
                throw new Exception("InvalidColumnSizesException");
            HTag table = new HTag("table", "\"width:100%\"");
            docCode.addAnyTag(table, "body");
        }

        public string InlineHTML()
        {
            return docCode.getHTMLCode();
        }
    }
}
