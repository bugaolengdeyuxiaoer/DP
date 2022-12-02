using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Memento
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
    public class Manager : Employee
    {
        public List<Employee> Employees = new();

        public Manager(int id, string name) : base(id, name)
        {

        }

    }

    public interface IEmployeeManagerRepository
    {
        void AddEmployee(int managerId, Employee employee);
        void RemoveEmployee(int managerId, Employee employee);
        bool HasEmployee(int managerId, Employee employee);
        void WriteDataStore();
    }

    public class EmployeManagerRepository : IEmployeeManagerRepository
    {
        private List<Manager> _managers = new() { new Manager(1, "Tom"), new Manager(2, "Jerry") };
        public void AddEmployee(int managerId, Employee employee)
        {
            _managers.First(m => m.Id == managerId).Employees.Add(employee);
        }

        public void RemoveEmployee(int managerId, Employee employee)
        {
            _managers.First(m => m.Id == managerId).Employees.Remove(employee);
        }

        public bool HasEmployee(int managerId, Employee employee)
        {
            return _managers.First(m => m.Id == managerId).Employees.Any(e => e.Id == employee.Id);
        }

        public void WriteDataStore()
        {
            foreach (var m in _managers)
            {
                Console.WriteLine($"Manager {m.Id}, {m.Name}");
                if (m.Employees.Any())
                {
                    foreach (var e in m.Employees)
                    {
                        Console.WriteLine($"\t Employee {e.Id}, {e.Name}");
                    }
                }
                else
                {
                    Console.WriteLine($"\t No employees");
                }
            }
        }


    }

    public interface ICommand
    {
        void Execute();
        bool CanExecute();

        void Undo();

    }
    public class AddEmployeeToManagerListMemento
    {
        public int ManagerId { get; private set; }
        public Employee? Employee { get; private set; }
        public AddEmployeeToManagerListMemento(int managerId, Employee? employee)
        {
            ManagerId = managerId;
            Employee = employee;
        }
    }
    public class AddEmployeeToManagerList: ICommand
    {
        private readonly IEmployeeManagerRepository _employeeManagerRepository;
        private  int _managerId;
        private  Employee? _employee;

        public AddEmployeeToManagerList(IEmployeeManagerRepository employeeManagerRepository, int managerId, Employee? employee)
        {
            _employeeManagerRepository = employeeManagerRepository;
            _managerId = managerId;
            _employee = employee;
        }

        public AddEmployeeToManagerListMemento CreateMemento()
        {
            return new AddEmployeeToManagerListMemento(_managerId, _employee);
        }

        public void RestoreMemento(AddEmployeeToManagerListMemento memento)
        {
            _managerId = memento.ManagerId;
            _employee = memento.Employee;
        }
        public bool CanExecute()
        {
            if (_employee == null)
                return false;
            if (_employeeManagerRepository.HasEmployee(_managerId, _employee))
            {
                return false;
            }
            return true;
        }

        public void Execute()
        {
            if (_employee == null)
                return;
            _employeeManagerRepository.AddEmployee(_managerId, _employee);
        }

        public void Undo()
        {
            if (_employee == null)
            {
                return;
            }
            _employeeManagerRepository.RemoveEmployee(_managerId, _employee);
        }
    }

    public class CommandManager
    {
        private Stack<AddEmployeeToManagerListMemento> _memento = new();
        private AddEmployeeToManagerList? _command;
        public void Invoke(ICommand command)
        {
            if(_command == null)
            {
                _command = (AddEmployeeToManagerList)command;
            }
            if (command.CanExecute())
            {
                _memento.Push(((AddEmployeeToManagerList)command).CreateMemento());
                command.Execute();
            }
        }
        public void Undo()
        {
            if (_memento.Any())
            {
                _command?.RestoreMemento(_memento.Pop());
                _command.Undo();
            }
        }
    }
}
