using System;
using System.Collections.Generic;
using System.Text;

namespace OpticSoftware.Security.Abstract
{
    public interface IHash
    {
        string Hash(string text);
    }
}
