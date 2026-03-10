using MoqTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoqTesting.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = new();

        public Employee? GetById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public IReadOnlyList<Employee> GetAll()
        {
            return _employees.AsReadOnly();
        }

        public void Add(Employee employee)
        {
            if (_employees.Any(e => e.Id == employee.Id))
                throw new InvalidOperationException($"Employee with Id {employee.Id} already exists.");

            _employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            var existing = _employees.FirstOrDefault(e => e.Id == employee.Id);
            if (existing is null)
                throw new KeyNotFoundException($"Employee with Id {employee.Id} not found.");

            existing.Name = employee.Name;
            existing.Position = employee.Position;
            existing.Salary = employee.Salary;
        }

        public void Delete(int id)
        {
            var existing = _employees.FirstOrDefault(e => e.Id == id);
            if (existing is null)
                throw new KeyNotFoundException($"Employee with Id {id} not found.");

            _employees.Remove(existing);
        }
    }
}

