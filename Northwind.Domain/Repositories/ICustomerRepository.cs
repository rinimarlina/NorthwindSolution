﻿using Northwind.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>>GetAllCustomer(bool trackChanges);
        Task<Customer> GetCustomerById(string customerId, bool trackChanges);
        void Insert(Customer customer);
        void Edit(Customer customer);
        void Remove(Customer customer);

    }
}
