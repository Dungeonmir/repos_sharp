using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practCsharp9_10
{
    internal class Film
    {
        private string _filmName;
        private string _filmProducer;
        private DateTime _dateOut;
        private Format _format;
        private Actor[] _actors;

        public Film()
            : this("Unknown name", "Unknown producer", DateTime.Now, Format.Cinema, new Actor[] {} )
        {

        }
        public Film(string filmName, string filmProducer, DateTime dateOut, Format format, Actor[] actors)
        {
            _filmName = filmName;
            _filmProducer = filmProducer;
            _dateOut = dateOut;
            _format = format;
            _actors = actors;
        }

        public string FilmName { 
            get 
            { 
                return _filmName;
            }
            set
            {
                _filmName = value;
            }
        }
        public string FilmProducer
        {
            get
            {
                return _filmProducer;
            }
            set
            {
                _filmProducer = value;
            }
        } 
        public DateTime DateOut
        {
            get {return _dateOut; }
            set { _dateOut = value; }
        }
        public Format Format {
            get { return _format; }
            set { _format = value; }
        }
        public Actor[] Actors {
            get { return _actors; }
            set { _actors = value; }
        }
        public Actor ActorBestFee
        {
            get
            {
                Actor requiredActor = null;
                foreach (Actor actor in _actors)
                {
                    int fee = 0;
                    
                    if (actor.Fee > fee)
                    {
                        requiredActor = actor;
                    }

                }
                return requiredActor;
            }
        }
        public bool isCinema
        {
            get
            {
                if (_format == Format.Cinema) return true;
                else
                return false;
            }
        }

        public void AddActors(params Actor[] actors)
        {
            _actors = _actors.Concat(actors).ToArray();
        }

        public override string ToString()
        {
            string str =  String.Format($"Название фильма: {_filmName}\nРежиссер: {_filmProducer}\nДата выхода: {_dateOut.ToShortDateString()}\n");
            str += "Список актеров: \n";
            foreach (Actor actor in _actors)
            {
                str += actor.Role+": ";
                str+=actor.Person.ToShortString();
            }
            return str;
        }
        public virtual string ToShortString()
        {
            return String.Format($"Название фильма: {_filmName}\nРежиссер: {_filmProducer}\nДата выхода: {_dateOut.ToShortDateString()}\n");
        }
    }
}
