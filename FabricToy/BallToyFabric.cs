using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabricToy
{
    internal class BallToyFabric: ToyFabric
    {
        int price;
        public override Itoy CreateToy()
        {
            return new BallToy(price);
        }
    }
}
