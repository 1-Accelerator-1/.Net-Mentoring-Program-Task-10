using CustomBinarySerialization.Services;
using Models;
using System;
using System.Collections.Generic;

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

            var binarySerializationService = new BinarySerializationService();

            try
            {
                binarySerializationService.Serialize("department1.dat", department);
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
                newDepartment = binarySerializationService.Deserialize("department1.dat");
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
