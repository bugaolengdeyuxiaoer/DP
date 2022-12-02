using System;

using Visitor;

Console.Title = "Visitor";

var container = new Container();
container.Customers.Add(new Customer("A", 132));
container.Customers.Add(new Customer("B", 52));
container.Customers.Add(new Customer("H", 132332));
container.Employees.Add(new Employee("Q", 6));
container.Employees.Add(new Employee("Y", 13));
container.Employees.Add(new Employee("P", 2));

DiscountVisitor discountVisitor = new();

container.Accept(discountVisitor);
Console.WriteLine($"Total discount: {discountVisitor.TotalDiscountGiven}");

