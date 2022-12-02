using System;

using Command;

Console.Title = "Command";

CommandManager commandManager = new();
IEmployeeManagerRepository repository = new EmployeManagerRepository();

commandManager.Invoke(new AddEmployeeToManagerList(repository, 1, new Employee(1, "a")));
repository.WriteDataStore();
commandManager.Invoke(new AddEmployeeToManagerList(repository, 2, new Employee(2, "b")));
repository.WriteDataStore();

commandManager.Invoke(new AddEmployeeToManagerList(repository, 2, new Employee(3, "c")));
repository.WriteDataStore();

commandManager.Invoke(new AddEmployeeToManagerList(repository, 2, new Employee(4, "d")));
repository.WriteDataStore();

commandManager.Invoke(new AddEmployeeToManagerList(repository, 2, new Employee(5, "e")));
repository.WriteDataStore();

Console.WriteLine("Undo!");
commandManager.Undo();
repository.WriteDataStore();
