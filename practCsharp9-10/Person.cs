using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practCsharp9_10
{
    internal class Person
    {
        private string _name;
        private string _surname;
        private DateTime _birth;
        public string Name {
            get { return _name; }
            set { _name = value; }
        }
        public string Surname {
            get { return _surname; }
            set { _surname = value; }
        }
        public DateTime birthday { 
            get { return _birth; }
            set { _birth = value; }
        }
        public int Year {
            get { return birthday.Year; }
            set {
                 _birth = new DateTime(value, _birth.Month, _birth.Day);
                }
        }
        public Person()
            :this("UnknownName", "UnknownSurname", DateTime.Now)
        {
        }

        public Person(string Name, string Surname,DateTime birthday)
        {
            _name = Name;
            _surname = Surname;
            _birth = birthday;
        }

        public override string ToString()
        {
            return string.Format($"Имя: {_name}\nФамилия: {_surname} Дата рождения: {birthday.ToShortDateString}\n");
        }
        public virtual string ToShortString()
        {
            return String.Format($"Имя: {_name} Фамилия: {_surname}\n");
        }
    }
    enum Format
    {
       TV,
       Cinema, 
       Online
    }
}
