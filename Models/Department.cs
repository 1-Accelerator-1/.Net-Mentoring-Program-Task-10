using System;
using System.Collections.Generic;

namespace Models
{
    [Serializable]
    public class Department
    {
        public string DepartmentName { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
