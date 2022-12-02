using System;

using Iterator;
Console.Title = "Iterator";

PeopleCollection people = new();

people.Add(new Person("A", "A"));
people.Add(new Person("B", "A"));
people.Add(new Person("D", "A"));
people.Add(new Person("C", "A"));

var peopleIterator = people.CreateIterator();
for(Person person = peopleIterator.First(); !peopleIterator.IsDone; person = peopleIterator.Next())
{
    Console.WriteLine($"Person {person.Name} from {person.Country}");
}
