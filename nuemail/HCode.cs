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
        private bool headFlag=false;
        private bool bodyFlag=false;

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

            // If both tags are inserted, throws an exception
            if (bodyFlag && headFlag)
                throw new Exception("AlreadyAddedException");

            if (!bodyFlag)
            {
                htmlCode.AddAfter(htmlCode.First, head.CreateSTag());
                htmlCode.AddBefore(htmlCode.Last, head.CreateETag());
                headFlag = true;
            }
            else
            {
                htmlCode.AddAfter(htmlCode.First, head.CreateSTag());
                htmlCode.AddBefore(htmlCode.Find(new HTag("body").CreateSTag()),
                    head.CreateETag());
            }
        }

        // Adds <body></body> tag
        public void addBodyTag()
        {
            HTag body = new HTag("body");

            // If both tags are inserted, throws an exception
            if (bodyFlag && headFlag)
                throw new Exception("AlreadyAddedException");

            if (headFlag)
            {
                htmlCode.AddAfter(htmlCode.Find(new HTag("head").CreateETag()),
                    body.CreateSTag());
                htmlCode.AddBefore(htmlCode.Last, body.CreateETag());
                bodyFlag = true;
            }
            else
            {
                htmlCode.AddAfter(htmlCode.First, body.CreateSTag());
                htmlCode.AddBefore(htmlCode.Last, body.CreateETag());
                bodyFlag = true;
            }
        }

        // Insert a any tag inside the any tags
        public void addAnyTag(HTag tag, string startAfter)
        {
            HTag temp = new HTag(startAfter);
            htmlCode.AddAfter(htmlCode.Find(temp.CreateSTag()),
                tag.CreateSTag());
            htmlCode.AddBefore(htmlCode.Find(temp.CreateETag()), tag.CreateETag());
        }

        // Returns the complete HTML code stored in the linked list
        public string getHTMLCode()
        {
            string code="";

            for (LinkedListNode<string> temp = htmlCode.First; 
                temp != htmlCode.Last; temp = temp.Next)
                code=code+temp.Value.ToString();
            code = code + htmlCode.Last.Value;

            return code;
        }          
    }
}
