using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.CTCI.OOODesigns.ex_7_2
{
    public abstract class Employee
    {
        public string Id { get; set; }
        public bool IsAvailable { get; set; } = true;
        public Employee UpperManager { get; set; }
        public Employee(string id, Employee upperManager)
        {
            this.Id = id;
            this.UpperManager = upperManager;
        }
        public bool HandleCall()
        {
            if (!this.IsAvailable)
            {
                if (UpperManager != null)
                {
                    return this.UpperManager.HandleCall();
                }
            }
            else
            {
                return this.DoHandleCall();
            }
            return false;
        }
        protected abstract bool DoHandleCall();
    }
    public class Respondent : Employee
    {
        public Respondent(string id, Employee upperManager) : base(id, upperManager)
        {
        }

        protected override bool DoHandleCall()
        {
            Console.WriteLine($"Respondent {Id} handled");
            return true;
        }
    }

    public abstract class ManagerEmployee : Employee
    {
        public List<Employee> Subordinates { get; set; } = new List<Employee>();
        public ManagerEmployee(string id, Employee upperManager) : base(id, upperManager)
        {
        }
    }
    public class Manager : ManagerEmployee
    {
        public Manager(string id, Employee upperManager) : base(id, upperManager)
        {
        }
        protected override bool DoHandleCall()
        {
            Console.WriteLine($"Manager {Id} handled");
            return true;
        }
    }
    public class Director : ManagerEmployee
    {
        public Director(string id, Employee upperManager) : base(id, upperManager)
        {
        }
        protected override bool DoHandleCall()
        {
            Console.WriteLine($"Director {Id} handled");
            return true;
        }
    }
    public class CallCenter
    {
        public enum EmployeeType
        {
            Director, Manager, Respondent
        }
        public Hashtable Directors { get; set; } = new Hashtable();
        public Hashtable Managers { get; set; } = new Hashtable();
        public Hashtable Respondents { get; set; } = new Hashtable();
        public void AddEmployee(string id, EmployeeType type, string manager)
        {
            ManagerEmployee mgr = null;
            if (manager != null)
            {
                foreach (DictionaryEntry de in this.Directors)
                {
                    if (de.Key == manager)
                    {
                        mgr = (ManagerEmployee)de.Value;
                        break;
                    }
                }
            }
            if (manager != null)
            {
                foreach (DictionaryEntry de in this.Managers)
                {
                    if (de.Key == manager)
                    {
                        mgr = (ManagerEmployee)de.Value;
                        break;
                    }
                }
            }
            Employee emp = null;
            switch (type)
            {
                case EmployeeType.Director:
                    emp = new Director(id, mgr);
                    this.Directors.Add(id, emp);
                    break;
                case EmployeeType.Manager:
                    emp = new Manager(id, mgr);
                    this.Managers.Add(id, emp);
                    break;
                case EmployeeType.Respondent:
                    emp = new Respondent(id, mgr);
                    this.Respondents.Add(id, emp);
                    break;
            }
            if (mgr != null)
            {
                mgr.Subordinates.Add(emp);
            }
        }
        private bool DispatchCallByLevels(EmployeeType type)
        {
            Hashtable employees = null;
            switch (type)
            {
                case EmployeeType.Respondent:
                    employees = this.Respondents;
                    break;
                case EmployeeType.Manager:
                    employees = this.Managers;
                    break;
                case EmployeeType.Director:
                    employees = this.Directors;
                    break;
            }
            if (employees.Count != 0)
            {
                foreach (DictionaryEntry r in employees)
                {
                    var employee = r.Value as Employee;
                    if (employee.IsAvailable)
                    {
                        return employee.HandleCall();
                    }
                }
            }
            return false;
        }
        public bool DispatchCall()
        {
            return this.DispatchCallByLevels(EmployeeType.Respondent) ||
            this.DispatchCallByLevels(EmployeeType.Manager) ||
            this.DispatchCallByLevels(EmployeeType.Director);
        }
    }
}
