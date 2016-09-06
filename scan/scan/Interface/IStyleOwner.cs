using System;
using System.Collections.Generic;
using System.Text;

namespace scan.Interface
{
    interface IStyleOwner
    {
        void setBillStyle(String styleName, String styleValue, string styleID);
    }
}
