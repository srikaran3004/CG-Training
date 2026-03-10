
using MoqTesting.Models;
using MoqTesting.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoqTesting.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _repo;
        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }
        public Employee GetEmployeeOrThrow(int id)
        {
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id), "Id must be positive.");
            var employee = _repo.GetById(id);
            if (employee is null)
            {
                throw new KeyNotFoundException($"Employee with id {id} not found.");
            }
            return employee;
        }
    }
}
