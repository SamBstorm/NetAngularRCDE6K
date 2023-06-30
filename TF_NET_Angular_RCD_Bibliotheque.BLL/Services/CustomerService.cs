using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_NET_Angular_RCD_Bibliotheque.BLL.Exceptions;
using TF_NET_Angular_RCD_Bibliotheque.DAL.Repositories;
using TF_NET_Angular_RCD_Bibliotheque.Models.DTOs.Cutomers;
using TF_NET_Angular_RCD_Bibliotheque.Models.Entities;
using TF_NET_Angular_RCD_Bibliotheque.Models.Mappers;

namespace TF_NET_Angular_RCD_Bibliotheque.BLL.Services
{
    public class CustomerService : ICustomerService
    {

        private ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        public CustomerFormDTO Add(CustomerFormDTO customer)
        {
            Customer? existingCustomer = _customerRepository.GetOne(c => c.Pseudo == customer.Pseudo);
            if(existingCustomer is not null)
            {
                throw new AlreadyExistException("Pseudo deja utilisé");
            }
            return _customerRepository.Add(customer.ToDAL()).ToDTO();
        }

        public CustomerFormDTO GetOne(int id)
        {
            Customer? customer = _customerRepository.GetOne(c => c.Id == id);
            if(customer is null)
            {
                throw new KeyNotFoundException("Il n'existe pas d'utilisateur avec cet id");
            }
            return customer.ToDTO();
        }

        public IEnumerable<CustomerFormDTO> GetMany()
        {
            return _customerRepository.GetMany().Select(c => c.ToDTO());
        }

        public bool Update(int id, CustomerFormDTO customer)
        {
            Customer? existingCustomer = _customerRepository.GetOne(c => c.Id == id);
            if (existingCustomer is null)
            {
                throw new KeyNotFoundException("Il n'existe pas d'utilisateur avec cet id");
            }
            Customer updated = customer.ToDAL();
            existingCustomer.Firstname = updated.Firstname;
            existingCustomer.Lastname = updated.Lastname;
            existingCustomer.Birthdate = updated.Birthdate;
            existingCustomer.Pseudo = updated.Pseudo;
            existingCustomer.Password = updated.Password;

            return _customerRepository.Update(existingCustomer);
        }

        public bool Delete(int id)
        {
            Customer? existingCustomer = _customerRepository.GetOne(c => c.Id == id);
            if (existingCustomer is null)
            {
                throw new KeyNotFoundException("Il n'existe pas d'utilisateur avec cet id");
            }
            return _customerRepository.Delete(existingCustomer);
        }

        public CustomerLoginDTO? Login(CustomerLoginDTO customer)
        {
            return _customerRepository.Login(customer.Pseudo, customer.Password.sha256_hash()).ToLoginDTO();
        }
    }
}
