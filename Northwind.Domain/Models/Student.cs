using System;
using System.Collections.Generic;

#nullable disable

namespace Northwind.Domain.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
    }
}
