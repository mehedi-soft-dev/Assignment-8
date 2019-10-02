using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.Repository;
using CoffeeShop.Model;

namespace CoffeeShop.Manager
{
    class CustomerInfoManager
    {
        CustomerInfoRepository _customerRepository = new CustomerInfoRepository();

        public bool AddCustomer(Customer customer)
        {
            return _customerRepository.AddCustomer(customer);
        }

        public bool IsCustomerExist(Customer customer)
        {
            return _customerRepository.IsCustomerExist(customer);
        }

        public DataTable Display()
        {
            return _customerRepository.Display();
        }

        public DataTable SearchCustomerByName(Customer customer)
        {
            return _customerRepository.SearchCustomerByName(customer);
        }

        public DataTable SearchCustomerById(Customer customer)
        {
            return _customerRepository.SearchCustomerById(customer);
        }

        public bool DeleteCustomer(int id)
        {
            return _customerRepository.DeleteCustomer(id);
        }

        public bool UpdateCustomer(int id, string name, string contact, string address)
        {
            return _customerRepository.UpdateCustomer(id, name, contact, address);
        }
    }
}
