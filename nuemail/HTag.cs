using System;
using System.Collections.Generic;
using System.Text;

namespace nuemail
{
    public class HTag : IHTag
    {
        // Tag operators
        protected static string hTagOpsL = "<";
        protected static string hTagOpsR = ">";
        protected static string hTagOpsT = "/";
        protected static string hTagOpsS = "'";
        protected static string hTagOpsEq = "=";

        // Space inside tags
        protected static string hTagSpace = " ";

        // HTML tag argz
        protected static string styleCode = "style=";
        protected static string classCode = "class=";

        // Content of an html tag
        private string tagName;
        private string className;
        private string style;
        private string[] argz;
        private string[] argzVal;
        private int tagLevel=0; // Variable to decide which level the tag is in


        // Basic constructor creates complete tag
        private HTag(string tag, string cname, string style, string[] argz, string[] 
            values)
        { 
            tagName = tag;
            className = classCode + cname;
            this.style = styleCode + style ;

            // If the number of arguments and number of values are not equal
            if (argz == null || values == null)
                return;
            if (argz.Length!=values.Length)
                throw new Exception("NArgumentsNValuesNotEqualException");

            this.argz = argz;
            this.argzVal = values;
            tagLevel = 10; // Tag level for completed complete styled tag
        }

        // Derrived constructor for style attribute
        public HTag(string tag, string style)
            : this(tag, null, style, null,null)
        {
            tagLevel = 3;
        }

        // Derrived constructor for style sheets
        public HTag(string tag, string cname, string[] argz, string[] values) : 
            this(tag,cname,null,argz,values)
        {
            tagLevel = 2; // Tag level for group style tag
        }

        // Derrived constructor creates a basic tag ex: <html>;
        public HTag(string tag) : this(tag,null,null,null,null)
        {
            tagLevel = 0; // Tag level for a basic tag
        }

        // Derrived constructor for simple styles ex: <a alt=''>
        public HTag(string tag,string[] argz,string[] valz) : 
            this(tag,null,null,argz,valz)
        {
            tagLevel = 1; // Tag level for a simple tag
        }

        // Implemented member functions
        public string CreateSTag()
        {
            string sTag;
            if (tagLevel == 0) // For a basic tag
            {
                sTag = hTagOpsL + tagName + hTagOpsR;
            }
            else if (tagLevel == 1) // For a simple tag
            {
                sTag = hTagOpsL + tagName + hTagSpace;
                for (int i = 0; i < argz.Length; i++)
                    sTag = sTag + argz[i] + hTagOpsEq + argzVal[i] +
                        hTagSpace;
                sTag = sTag + hTagOpsR;
            }
            else if (tagLevel == 2) // For a complicated stylish tag
            {
                sTag = hTagOpsL + tagName + hTagSpace + className + hTagSpace;
                for (int i = 0; i < argz.Length; i++)
                    sTag = sTag + argz[i] + hTagOpsEq + argzVal[i] +
                        hTagSpace;
                sTag = sTag + hTagOpsR;
            }
            else if (tagLevel == 3) // For a complicated stylish tag
            {
                sTag = hTagOpsL + tagName + hTagSpace + style + hTagOpsR;
            }
            else
                sTag = hTagOpsL + hTagOpsR;

            return sTag;
        }

        public string CreateETag()
        {
            string sTag;

            // Termination of the tag
            sTag = hTagOpsL + hTagOpsT + tagName + hTagOpsR;

            return sTag;
        }

        public string ToString()
        {
            return CreateSTag()+CreateETag();
        }
    }
}
