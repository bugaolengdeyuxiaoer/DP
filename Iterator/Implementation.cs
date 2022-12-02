using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Iterator
{
    public class Person
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public Person(string name, string country)
        {
            Name = name;
            Country = country;
        }
    }

    public interface IPeopleIterator
    {
        Person First();
        Person Last();
        Person Next();

        Person CurrentItem { get; }

        bool IsDone { get; }
    }

    public interface IPeopleCollection
    {
        IPeopleIterator CreateIterator();
    }

    public class PeopleCollection : List<Person>, IPeopleCollection
    {
        public IPeopleIterator CreateIterator()
        {
            return new PeopleIterator(this);
        }
    }

    public class PeopleIterator : IPeopleIterator
    {

        private PeopleCollection _peopleCollection;
        private int _current = 0;
        public Person CurrentItem
        {
            get
            {
                return _peopleCollection.OrderBy(p => p.Name).ToList()[_current];
            }
        }

        public bool IsDone
        {
            get { return _current >= _peopleCollection.Count; }
        }
        public PeopleIterator(PeopleCollection peopleCollection)
        {
            _peopleCollection = peopleCollection;
        }

        public Person First()
        {
            _current = 0;
            return _peopleCollection.OrderBy(p => p.Name).ToList()[_current];
        }

        public Person Last()
        {
            return _peopleCollection.Last();
        }

        public Person Next()
        {
            _current++;
            if (!IsDone)
            {
                return _peopleCollection.OrderBy(p => p.Name).ToList()[_current];
            }
            else
            {
                return null;
            }
        }
    }
}
