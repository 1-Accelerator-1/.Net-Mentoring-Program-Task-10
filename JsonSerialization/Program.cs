using CustomBinarySerialization.Services;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomBinarySerialization
{
    internal class Program
    {
        static async Task Main(string[] args)
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

            var jsonSerializationService = new JsonSerializationService();

            try
            {
                await jsonSerializationService.Serialize("department2.json", department);
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
                newDepartment = await jsonSerializationService.Deserialize("department2.json");
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
