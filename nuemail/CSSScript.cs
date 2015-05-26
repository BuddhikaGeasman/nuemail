using System;
using System.Collections.Generic;
using System.Text;

namespace nuemail
{
    public class CSSScript:ICSSScript
    {
        // CSS operators
        protected string CSSOpsDot = ".";
        protected string CSSOpsColon = ":";
        protected string CSSOpsSColon = ";";
        protected string CSSOpsCBracL = "{";
        protected string CSSOpsCBracR = "}";

        // CSS format parameters
        private string cName;
        private string[] paramStyle;

        // Initialize the class with one parameter
        public CSSScript(string classname,string parameter,string value)
        {
            cName = classname;
            paramStyle = new string[] { parameter + CSSOpsColon + 
                value + CSSOpsSColon };
        }

        // Initialize the class with no parameters
        public CSSScript(string classname)
        {
            cName = classname;
            paramStyle = null;
        }

        // Create a CSS class with attributes
        public string CreateCTags()
        {
            string strCSSClass;

            strCSSClass = CSSOpsDot + cName + CSSOpsCBracL;
            if (paramStyle!=null)
                for (int i = 0; i < paramStyle.Length; i++)
                    strCSSClass = strCSSClass + paramStyle[i].ToString();
            strCSSClass = strCSSClass + CSSOpsCBracR;

            return strCSSClass;
        }

        // Adds parameters to the CSS class
        public void addParam(string param, string value)
        {
            if (paramStyle!=null)
                paramStyle = new string[] {paramStyle[paramStyle.Length-1],  
                    param + CSSOpsColon + value + CSSOpsSColon };
            else
                paramStyle = new string[] { param + CSSOpsColon + 
                    value + CSSOpsSColon };
        }

        public string ToString()
        {
            return CreateCTags();
        }


    }
}
