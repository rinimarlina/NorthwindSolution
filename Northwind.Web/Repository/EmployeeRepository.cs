using Northwind.Web.Models;
using System;
using System.Collections.Generic;

namespace Northwind.Web.Repository
{
    public class EmployeeRepository : IEmployee
    {
        List<Employee> IEmployee.GetAll()
        {
            var listOfEmployee = new List<Employee>()
            {
                new Employee {Id=1001,Name="Rini Marlina", BirthDate=new DateTime(1999,08,04) },
                new Employee {Id=1002,Name="Celine", BirthDate=new DateTime(2001,01,12) },
                new Employee {Id=1003,Name="Arya", BirthDate=new DateTime(2002,10,18) },
                new Employee {Id=1004,Name="Santi", BirthDate=new DateTime(2003,10,18) }

            };
            return listOfEmployee;
        }
    }
}
