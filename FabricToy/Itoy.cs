using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricToy
{
    internal interface Itoy
    {
        string Name { get; }
        int GetPrice();
        string GetFullDescription();

    }
}
