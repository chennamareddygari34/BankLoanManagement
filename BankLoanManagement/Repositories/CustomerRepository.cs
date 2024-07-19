using BankLoanManagement.Interfaces;
using BankLoanManagement.Models;
using BankLoanManagement.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Net;
using System.Reflection;

namespace BankLoanManagement.Repositories
{
    public class CustomerRepository : ICustomerRepository<int, Customer>
    {
        private readonly BankLoanApplicationContext _context;
        public CustomerRepository(BankLoanApplicationContext context)
        {
            _context = context;
        }

        public List<CustomerDTO> GetAllCustomer()
        {

            var customer = _context.Customers.Select(e => new CustomerDTO
            {
               
                CustomerId = e.CustomerId,
                AccountNumber = e.AccountNumber,
                FirstName = e.FirstName,
                Email = e.Email,
                LastName = e.LastName,
                FullName = e.FullName,
                PhoneNumber = e.PhoneNumber,
                DateOfBirth = e.DateOfBirth,
                Gender = e.Gender,
                MaritalStatus = e.MaritalStatus,
                OccupationType = e.OccupationType,
                AddressId = e.AddressId,
                Address = e.AddressId == null ? null : new CustomerAddress
                {

                    HouseNo = e.Address.HouseNo,
                    City = e.Address.City,
                    District = e.Address.District,
                    State = e.Address.State,
                    Landmark = e.Address.Landmark,
                    Pincode = e.Address.Pincode,
                    Country = e.Address.Country
                }
            }).ToList();
            return customer;
        }




        public CustomerDTO GetCustomerById(int customerId)
        {
            var customer = _context.Customers
                .Where(e => e.CustomerId == customerId)
                .Select(e => new CustomerDTO
                {
                    CustomerId = e.CustomerId,
                    AccountNumber = e.AccountNumber,
                    FullName = e.FullName,
                    FirstName = e.FirstName,
                    Email = e.Email,
                    LastName = e.LastName,
                    PhoneNumber = e.PhoneNumber,
                    DateOfBirth = e.DateOfBirth,
                    Gender = e.Gender,
                    MaritalStatus = e.MaritalStatus,
                    OccupationType = e.OccupationType,
                    AddressId = e.AddressId,
                    Address = e.AddressId == null ? null : new CustomerAddress
                    {
                        HouseNo = e.Address.HouseNo,
                        City = e.Address.City,
                        District = e.Address.District,
                        State = e.Address.State,
                        Landmark = e.Address.Landmark,
                        Pincode = e.Address.Pincode,
                        Country = e.Address.Country
                    }
                }).FirstOrDefault();

            return customer;
        }



        public Customer DeleteCustomerById(int CustomerId)
        {
            var customer = _context.Customers.Find(CustomerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
            return customer;
        }

        public CustomerDTO UpdateCustomer(CustomerDTO customerDTO)
        {

            var customer = _context.Customers.FirstOrDefault(e => e.CustomerId == customerDTO.CustomerId);

            if (customer == null)
            {
                return null;
            }

            customer.FirstName = customerDTO.FirstName;
            customer.AccountNumber = customerDTO.AccountNumber;
            customer.FullName = customerDTO.FullName;
            customer.Email = customerDTO.Email;
            customer.LastName = customerDTO.LastName;
            customer.PhoneNumber = customerDTO.PhoneNumber;
            customer.DateOfBirth = customerDTO.DateOfBirth;
            customer.Gender = customerDTO.Gender;
            customer.MaritalStatus = customerDTO.MaritalStatus;
            customer.OccupationType = customerDTO.OccupationType;


            if (customerDTO.Address != null)
            {
                var address = _context.CustomerAddresses.FirstOrDefault(a => a.AddressId == customerDTO.AddressId);

                if (address != null)
                {
                    address.HouseNo = customerDTO.Address.HouseNo;
                    address.City = customerDTO.Address.City;
                    address.District = customerDTO.Address.District;
                    address.State = customerDTO.Address.State;
                    address.Landmark = customerDTO.Address.Landmark;
                    address.Pincode = customerDTO.Address.Pincode;
                    address.Country = customerDTO.Address.Country;
                }
            }


            _context.SaveChanges();


            var updatedCustomerDTO = new CustomerDTO
            {
                CustomerId = customer.CustomerId,
                AccountNumber = customer.AccountNumber,
                FullName = customer.FullName,
                FirstName = customer.FirstName,
                Email = customer.Email,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                DateOfBirth = customer.DateOfBirth,
                Gender = customer.Gender,
                MaritalStatus = customer.MaritalStatus,
                OccupationType = customer.OccupationType,
                AddressId = customer.AddressId,
                Address = customer.AddressId == null ? null : new CustomerAddress
                {
                    AddressId = customer.Address.AddressId,
                    HouseNo = customer.Address.HouseNo,
                    City = customer.Address.City,
                    District = customer.Address.District,
                    State = customer.Address.State,
                    Landmark = customer.Address.Landmark,
                    Pincode = customer.Address.Pincode,
                    Country = customer.Address.Country
                }
            };

            return updatedCustomerDTO;
        }

        public CustomerDTO AddCustomer(CustomerDTO customerDTO)
        {
            
                var customer = new Customer
                {
                    CustomerId = customerDTO.CustomerId,
                    AccountNumber = customerDTO.AccountNumber,
                    FirstName = customerDTO.FirstName,
                    FullName = customerDTO.FullName,
                    Email = customerDTO.Email,
                    LastName = customerDTO.LastName,
                    PhoneNumber = customerDTO.PhoneNumber,
                    DateOfBirth = customerDTO.DateOfBirth,
                    Gender = customerDTO.Gender,
                    MaritalStatus = customerDTO.MaritalStatus,
                    OccupationType = customerDTO.OccupationType,
                    AddressId = customerDTO.AddressId,
                    Address = customerDTO.AddressId == null ? null : new CustomerAddress
                    {
                        AddressId = customerDTO.Address.AddressId,
                        HouseNo = customerDTO.Address.HouseNo,
                        City = customerDTO.Address.City,
                        District = customerDTO.Address.District,
                        State = customerDTO.Address.State,
                        Landmark = customerDTO.Address.Landmark,
                        Pincode = customerDTO.Address.Pincode,
                        Country = customerDTO.Address.Country
                    }
                };

                _context.Customers.Add(customer);
                 _context.SaveChangesAsync();

                customerDTO.CustomerId = customer.CustomerId;
                return customerDTO;
            
        }
    }
}
