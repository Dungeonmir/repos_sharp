using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace FabricToy
{
    internal class BallToy : Itoy
    {
        private readonly string _name;
        private readonly int _price;
        public BallToy(int price)
        {
            _name = "Мяч";
            _price = price;
        }
        public string Name => _name;
        public int GetPrice() => _price;
        public string GetFullDescription()
        {
            return "Name: " + _name + " Price: " + _price;
        }
    }
}
