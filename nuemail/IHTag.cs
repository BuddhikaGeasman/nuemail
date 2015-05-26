using System;
using System.Collections.Generic;
using System.Text;

namespace nuemail
{   
    public interface IHTag
    {
        // customizablle htag methods
        string CreateSTag(); // Starts html tag Eg: <html>
        string CreateETag(); // Ends html tag Eg: </html>
        string ToString(); // Full text of the tag Eg: <html></html>
    }
}
