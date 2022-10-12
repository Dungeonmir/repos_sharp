using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pract14_semenov_39_02
{
    internal class Mass
    {
        private string _name;
        private decimal _value;
        public string Name 
        { 
            get { return _name;}
            set { _name = value; }
        }
        public decimal Value
        {
            get { return _value;}
            set { _value = value; }
        }
        public Mass(decimal value, string name)
        {
            _value = value;
            _name = name;
        }
        public override string ToString()
        {
            return _value.ToString()+" " +_name;
        }
    }
}
