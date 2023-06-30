using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TF_NET_Angular_RCD_Bibliotheque.Models.DTOs.Cutomers;
using TF_NET_Angular_RCD_Bibliotheque.Models.Entities;

namespace TF_NET_Angular_RCD_Bibliotheque.BLL.Services
{
    public interface ICustomerService
    {
        public CustomerFormDTO Add(CustomerFormDTO customer);
        public CustomerFormDTO GetOne(int id);
        public IEnumerable<CustomerFormDTO> GetMany();
        public bool Update(int id, CustomerFormDTO customer);
        public bool Delete(int id);
        public CustomerLoginDTO? Login(CustomerLoginDTO customer);
    }
}
