using System;
using Prototype;

Console.Title = "Prototype";

var manager = new Manager("Cindy");
var managerClone = manager.Clone();

Console.WriteLine($"Manager was cloned: {managerClone.Name}");

var employee = new Employee("Kevin",manager);
var employeeClone = (Employee)employee.Clone(true);

/**
 * MemberwiseClone only shallow copy.
 */
Console.WriteLine($"Are these two manager same object ? {employeeClone.Manager == manager}");
Console.WriteLine($"Employee was cloned: {employeeClone.Name} and maneger name {employeeClone.Manager.Name}");
manager.Name = "Cate";
/**
 * employee name will also change to cate.
 */
// fdsafdsaf
Console.WriteLine($"Employee was cloned: {employeeClone.Name} and maneger name {employeeClone.Manager.Name}");

