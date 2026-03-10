using System;
using System.Collections.Generic;
using System.Text;

namespace MoqTesting.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } =string.Empty;
        public string Position { get; set; }=string.Empty;
        public decimal Salary { get; set; }
    }
}
