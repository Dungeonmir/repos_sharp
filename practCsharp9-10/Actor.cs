using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practCsharp9_10
{
    internal class Actor
    {
        private string _role;
        private Person _person;
        private int _fee;
        public string Role
        {
            get { return _role; }
            set { _role = value; }
        }
        public Person Person
        {
            get { return _person; }
            set { _person = value; }
        }
        public int Fee
        {
            get { return _fee; }
            set { _fee = value; }
        }

        public Actor()
            :this("", new Person(), 5000)
        {

        }
        public Actor(string role, Person person, int fee)
        {
            _role = role;
            _person = person;
            _fee = fee;
        }
    }
}
