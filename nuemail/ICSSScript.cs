using System;
using System.Collections.Generic;
using System.Text;

namespace nuemail
{
    public interface ICSSScript
    {
        string CreateCTags();
        void addParam(string param,string value);
    }
}
