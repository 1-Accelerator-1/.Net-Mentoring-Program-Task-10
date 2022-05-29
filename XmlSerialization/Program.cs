using Models;
using System;
using System.Collections.Generic;
using CustomBinarySerialization.Services;

namespace CustomBinarySerialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var department = new Department
            {
                DepartmentName = "Department Name 1",
                Employees = new List<Employee>
                {
                    new Employee { EmployeeName = "Employee Name 1" },
                    new Employee { EmployeeName = "Employee Name 2" },
                    new Employee { EmployeeName = "Employee Name 3" },
                }
            };

            var binarySerializationService = new XmlSerializationService();

            try
            {
                binarySerializationService.Serialize("department3.xml", department);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Serialization failed.");
                Console.WriteLine(ex.Message);
                return;
            }

            Department newDepartment;
            try
            {
                newDepartment = binarySerializationService.Deserialize("department3.xml");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Deserialization failed.");
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine("Department: ");
            Console.WriteLine($"Name: {newDepartment.DepartmentName}");
            Console.WriteLine("Employees: ");

            foreach (var employee in newDepartment.Employees)
            {
                Console.WriteLine($"Name: {employee.EmployeeName}");
            }
        }
    }
}
