using System;
using System.Collections.Generic;
using System.Text;

namespace nuemail
{
    public class HCode
    {
        // A linked list to define HTML code strings
        private LinkedList<string> htmlCode;

        // Flags for inserted tags
        private bool headTag;
        private bool bodyTag;

        public HCode()
        {
            htmlCode = new LinkedList<string>();
            initializeHCode();
        }

        // Adds <html></html> tags to the linked list
        private void initializeHCode()
        {
            HTag html=new HTag("html");
            htmlCode.AddFirst(html.CreateSTag());
            htmlCode.AddLast(html.CreateETag());
        }

        // Adds <head></head> tags
        public void addHeadTag()
        {
            HTag head = new HTag("head");
            htmlCode.AddAfter(htmlCode.First,head.CreateSTag());
            htmlCode.AddBefore(htmlCode.Last, head.CreateETag());
        }

        // Adds <body></body> tag
        public void addBodyTag()
        {
            HTag body = new HTag("body");
            htmlCode.AddAfter(htmlCode.Find(new HTag("head").CreateETag()),
                body.CreateSTag());
            htmlCode.AddBefore(htmlCode.Last, body.CreateETag());
        }

        // Returns the complete HTML code stored in the linked list
        public string getHTMLCode()
        {
            string code="";

            for (LinkedListNode<string> temp = htmlCode.First; temp != htmlCode.Last; temp = temp.Next)
                code=code+temp.Value.ToString();
            code = code + htmlCode.Last.Value;

            return code;
        }          
    }
}
